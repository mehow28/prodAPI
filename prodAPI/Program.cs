using Microsoft.EntityFrameworkCore;
using prodAPI.Services;
using prodAPI.Models;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Azure.Identity;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // Use the default property (Pascal) casing
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Conn");
builder.Services.AddDbContext<production_dbContext>(x => x.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services.AddScoped<IEtapyRepository, EtapyRepository>();
builder.Services.AddScoped<IKontumRepository, KontumRepository>();
builder.Services.AddScoped<IMaszynyRepository, AuthenticationRepository>();
builder.Services.AddScoped<IPracownicyRepository, PracownicyRepository>();
builder.Services.AddScoped<IProduktyRepository, ProduktyRepository>();
builder.Services.AddScoped<ISurowceRepository, SurowceRepository>();
builder.Services.AddScoped<ISurowceDlaEtapuRepository, SurowceDlaEtapuRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IZleceniumRepository, ZleceniumRepository>();
builder.Services.AddScoped<IAwariaRepository, AwariaRepository>();
builder.Services.AddScoped<IHelperRepository, HelperRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:8100", "http://localhost:8101")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("MyAllowSpecificOrigins");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

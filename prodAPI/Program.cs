using Microsoft.EntityFrameworkCore;
using prodAPI.Services;
using prodAPI.Models;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Conn1");
builder.Services.AddDbContext<production_dbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IEtapyRepository, EtapyRepository>();
builder.Services.AddScoped<IKontumRepository, KontumRepository>();
builder.Services.AddScoped<IMaszynyRepository, MaszynyRepository>();
builder.Services.AddScoped<IPracownicyRepository, PracownicyRepository>();
builder.Services.AddScoped<IProduktyRepository,ProduktyRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IZleceniumRepository, ZleceniumRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

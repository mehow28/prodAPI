using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using prodAPI.Models;
using prodAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace prodAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly production_dbContext _DbContext;

        public AuthenticationController(IMapper mapper, IConfiguration configuration, production_dbContext dbContext)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public class AuthenticationRequestBody
        {
            public string? Login { get; set; }
            public string? Password { get; set; }  
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(
            AuthenticationRequestBody authenticationRequestBody)
        {
           /* var user = ValidateUserCredentials(
                authenticationRequestBody.Login,
                authenticationRequestBody.Password);
*/
            var dbUser = _DbContext.Konties.Where(x => x.Login == authenticationRequestBody.Login
                      && (x.Haslo == BitConverter.GetBytes(KontumRepository.GetUInt64Hash(SHA256.Create(), authenticationRequestBody.Password)))).FirstOrDefault();

            if (dbUser == null)
                return Unauthorized();

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", dbUser.IdKonta.ToString()));
            claimsForToken.Add(new Claim("name", dbUser.IdPracownika.ToString()));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn;
        }

       
    }
}

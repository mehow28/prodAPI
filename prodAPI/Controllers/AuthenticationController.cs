using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prodAPI.Models;

namespace prodAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public class AuthenticationRequestBody
        {
            public string? Login { get; set; }
            public string? Password { get; set; }  
        }

       /* [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(
            AuthenticationRequestBody authenticationRequestBody)
        {
            var user = ValidateUserCredentials(
                authenticationRequestBody.Login,
                authenticationRequestBody.Password);
        }

        private KontumDto ValidateUserCredentials(string? login, string? password)
        {
            if(login)
        }*/
    }
}

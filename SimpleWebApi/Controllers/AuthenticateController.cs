using SimpleWebApi.Helpers;
using SimpleWebApi.Models;
using System.Web.Http;

namespace SimpleWebApi.Controllers
{
    public class AuthenticateController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] AuthenticationParameters parameters)
        {
            var authenticationResult = CheckCredentialsHelper.IsEmailValid(parameters) && CheckCredentialsHelper.IsPasswordValid(parameters);
            return authenticationResult ? Ok(true) : Ok(false);
        }
    }
}

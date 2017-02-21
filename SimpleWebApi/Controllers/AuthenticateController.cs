using SimpleWebApi.Models;
using SimpleWebApi.Repositories;
using System.Web.Http;

namespace SimpleWebApi.Controllers
{
    public class AuthenticateController : ApiController
    {
        private CredentialsRepository _credentialsRepository;

        public AuthenticateController(CredentialsRepository credentialsRepository)
        {
            _credentialsRepository = credentialsRepository;
        }

        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] AuthenticationParameters parameters)
        {
            var authenticationResult = _credentialsRepository.AreCredentialsValid(parameters.Email, parameters.Password);
            return authenticationResult ? Ok(true) : Ok(false);
        }
    }
}

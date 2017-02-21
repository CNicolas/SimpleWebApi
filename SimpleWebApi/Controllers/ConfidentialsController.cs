using SimpleWebApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SimpleWebApi.Controllers
{
    public class ConfidentialsController : ApiController
    {
        public const string Realm = "SimpleWebApi";

        private CredentialsRepository _credentialsRepository;

        public ConfidentialsController(CredentialsRepository credentialsRepository)
        {
            _credentialsRepository = credentialsRepository;
        }

        [HttpGet]
        public IHttpActionResult ConfidentialsGet()
        {
            var authorizationHeader = GetAuthorizationHeaderValue();
            if (!string.IsNullOrWhiteSpace(authorizationHeader))
            {
                var authorizationHeaderValue = AuthenticationHeaderValue.Parse(authorizationHeader);

                if (CheckFormatOfAuthorizationHeader(authorizationHeaderValue))
                {
                    if (_credentialsRepository.ParseAndCheckBase64CredentialsString(authorizationHeaderValue.Parameter))
                    {
                        return Ok(true);
                    }

                    return Ok(false);
                }
            }

            var resultAuthenticationHeader = new AuthenticationHeaderValue("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            return Unauthorized(resultAuthenticationHeader);
        }

        /// <summary>
        /// Using a POST and an email in body, but unused as the Authorization header already contains the encoded email:password.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult ConfidentialsPost([FromBody] string email)
        {
            var authorizationHeader = GetAuthorizationHeaderValue();
            if (!string.IsNullOrWhiteSpace(authorizationHeader))
            {
                var authorizationHeaderValue = AuthenticationHeaderValue.Parse(authorizationHeader);

                if (CheckFormatOfAuthorizationHeader(authorizationHeaderValue))
                {
                    if (_credentialsRepository.ParseAndCheckBase64CredentialsString(authorizationHeaderValue.Parameter))
                    {
                        return Ok(true);
                    }

                    return Ok(false);
                }
            }

            var resultAuthenticationHeader = new AuthenticationHeaderValue("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            return Unauthorized(resultAuthenticationHeader);
        }

        private string GetAuthorizationHeaderValue()
        {
            IEnumerable<string> headerValues;
            var isHeaderPresent = Request.Headers.TryGetValues("Authorization", out headerValues);

            return isHeaderPresent ? headerValues.FirstOrDefault() : null;
        }

        private bool CheckFormatOfAuthorizationHeader(AuthenticationHeaderValue authorizationHeaderValue)
        {
            return authorizationHeaderValue.Scheme.Equals("Basic") && !string.IsNullOrWhiteSpace(authorizationHeaderValue.Parameter);
        }
    }
}

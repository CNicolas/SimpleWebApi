using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebApi.Controllers;
using SimpleWebApi.Models;
using SimpleWebApi.Repositories;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleWebApi.Tests
{
    [TestClass]
    public class AuthenticateControllerTests
    {
        private CredentialsRepository credentialsRepository;

        [TestInitialize]
        public void Setup()
        {
            // Here I can mock the repository if needed
            credentialsRepository = new CredentialsRepository();
        }

        [TestMethod]
        public void Should_Call_Authenticate_With_Post_And_Receive_Ok_True()
        {
            var authenticationParameters = new AuthenticationParameters()
            {
                Email = "c.nicolas@test.com",
                Password = "motdepasse"
            };

            var controller = new AuthenticateController(credentialsRepository);
            IHttpActionResult actionResult = controller.Authenticate(authenticationParameters);
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, contentResult.Content);
        }

        [TestMethod]
        public void Should_Call_Authenticate_With_Post_And_Receive_Ok_False()
        {
            var authenticationParameters = new AuthenticationParameters()
            {
                Email = "c.nicolas@test.com",
                Password = "password"
            };

            var controller = new AuthenticateController(credentialsRepository);
            IHttpActionResult actionResult = controller.Authenticate(authenticationParameters);
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content);
        }
    }
}

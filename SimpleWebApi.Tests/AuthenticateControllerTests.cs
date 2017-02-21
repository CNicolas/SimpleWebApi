using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebApi.Controllers;
using SimpleWebApi.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleWebApi.Tests
{
    [TestClass]
    public class AuthenticateControllerTests
    {
        [TestMethod]
        public void Should_Call_Authenticate_With_Post_And_Receive_Ok_True()
        {
            var authenticationParameters = new AuthenticationParameters()
            {
                Email = "clement.nicolas@test.com",
                Password = "motdepasse"
            };

            var controller = new AuthenticateController();
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
                Email = "clement.nicolas@test.com",
                Password = "motdepasse2"
            };

            var controller = new AuthenticateController();
            IHttpActionResult actionResult = controller.Authenticate(authenticationParameters);
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content);
        }
    }
}

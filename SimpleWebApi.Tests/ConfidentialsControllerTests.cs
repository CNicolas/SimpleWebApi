using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebApi.Controllers;
using SimpleWebApi.Repositories;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleWebApi.Tests
{
    [TestClass]
    public class ConfidentialsControllerTests
    {
        private CredentialsRepository credentialsRepository;

        [TestInitialize]
        public void Setup()
        {
            // Here I can mock the repository if needed
            credentialsRepository = new CredentialsRepository();
        }

        [TestMethod]
        public void Should_Call_Confidentials_With_Get_And_Receive_Unauthorized()
        {
            var controller = new ConfidentialsController(credentialsRepository);
            controller.Request = new HttpRequestMessage();

            IHttpActionResult actionResult = controller.ConfidentialsGet();
            var contentResult = actionResult as UnauthorizedResult;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Challenges);
            Assert.AreEqual("WWW-Authenticate", contentResult.Challenges.ElementAt(0).Scheme);
            Assert.AreEqual("Basic realm=\"SimpleWebApi\"", contentResult.Challenges.ElementAt(0).Parameter);
        }

        [TestMethod]
        public void Should_Call_Confidentials_With_Get_And_Receive_Ok_True()
        {
            var base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes("c.nicolas@test.com:motdepasse"));

            var controller = new ConfidentialsController(credentialsRepository);
            controller.Request = new HttpRequestMessage();
            controller.Request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64String);

            IHttpActionResult actionResult = controller.ConfidentialsGet();
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, contentResult.Content);
        }

        [TestMethod]
        public void Should_Call_Confidentials_With_Get_And_Receive_Ok_False()
        {
            var controller = new ConfidentialsController(credentialsRepository);
            controller.Request = new HttpRequestMessage();
            controller.Request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "Something Or Somewhere");

            IHttpActionResult actionResult = controller.ConfidentialsGet();
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content);
        }

        [TestMethod]
        public void Should_Call_Confidentials_With_Post_And_Receive_Unauthorized()
        {
            var controller = new ConfidentialsController(credentialsRepository);
            controller.Request = new HttpRequestMessage();

            IHttpActionResult actionResult = controller.ConfidentialsPost("rien");
            var contentResult = actionResult as UnauthorizedResult;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Challenges);
            Assert.AreEqual("WWW-Authenticate", contentResult.Challenges.ElementAt(0).Scheme);
            Assert.AreEqual("Basic realm=\"SimpleWebApi\"", contentResult.Challenges.ElementAt(0).Parameter);
        }

        [TestMethod]
        public void Should_Call_Confidentials_With_Post_And_Receive_Ok_True()
        {
            var base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes("c.nicolas@test.com:motdepasse"));

            var controller = new ConfidentialsController(credentialsRepository);
            controller.Request = new HttpRequestMessage();
            controller.Request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64String);

            IHttpActionResult actionResult = controller.ConfidentialsPost("rien");
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, contentResult.Content);
        }

        [TestMethod]
        public void Should_Call_Confidentials_With_Post_And_Receive_Ok_False()
        {
            var controller = new ConfidentialsController(credentialsRepository);
            controller.Request = new HttpRequestMessage();
            controller.Request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "Something Or Somewhere");

            IHttpActionResult actionResult = controller.ConfidentialsPost("rien");
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content);
        }
    }
}

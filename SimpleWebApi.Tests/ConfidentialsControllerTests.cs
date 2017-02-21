using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebApi.Controllers;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleWebApi.Tests
{
    [TestClass]
    public class ConfidentialsControllerTests
    {
        [TestMethod]
        public void Should_Call_Confidentials_With_Get_And_Receive_Unauthorized()
        {
            var controller = new ConfidentialsController();
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
            var controller = new ConfidentialsController();
            controller.Request = new HttpRequestMessage();
            controller.Request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "Y2xlbWVudC5uaWNvbGFzQHRlc3QuY29tOm1vdGRlcGFzc2U=");

            IHttpActionResult actionResult = controller.ConfidentialsGet();
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, contentResult.Content);
        }

        [TestMethod]
        public void Should_Call_Confidentials_With_Get_And_Receive_Ok_False()
        {
            var controller = new ConfidentialsController();
            controller.Request = new HttpRequestMessage();
            controller.Request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "Quelque chose");

            IHttpActionResult actionResult = controller.ConfidentialsGet();
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content);
        }

        [TestMethod]
        public void Should_Call_Confidentials_With_Post_And_Receive_Unauthorized()
        {
            var controller = new ConfidentialsController();
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
            var controller = new ConfidentialsController();
            controller.Request = new HttpRequestMessage();
            controller.Request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "Y2xlbWVudC5uaWNvbGFzQHRlc3QuY29tOm1vdGRlcGFzc2U=");

            IHttpActionResult actionResult = controller.ConfidentialsPost("rien");
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, contentResult.Content);
        }

        [TestMethod]
        public void Should_Call_Confidentials_With_Post_And_Receive_Ok_False()
        {
            var controller = new ConfidentialsController();
            controller.Request = new HttpRequestMessage();
            controller.Request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "Quelque chose");

            IHttpActionResult actionResult = controller.ConfidentialsPost("rien");
            var contentResult = actionResult as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(false, contentResult.Content);
        }
    }
}

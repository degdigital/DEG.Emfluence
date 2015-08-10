using System.Configuration;
using DEG.Emfluence.Models;
using DEG.ServiceCore.Authentication;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Emfluence.Tests
{
    [TestFixture]
    [Category("Integration")]
    public class EmfluenceServiceTests
    {
        private IEmfluenceService _sut;

        [SetUp]
        public void TestSetup()
        {
            var accessToken = ConfigurationManager.AppSettings["accessToken"];

            if (string.IsNullOrEmpty(accessToken))
                Assert.Inconclusive("You must set the access token for integration tests to run.");

            var auth = new ApplicationOnlyAuth(accessToken);
            _sut = new EmfluenceService(auth);
        }

        [Test]
        public void CanRetrieveNumberOfTweetsRequested()
        {
            var criteria = new SearchGroupsRequest();
            var response = _sut.SearchGroups(criteria);

            response.Success.Should().Be(1);
            response.Data.Records.Should().NotBeEmpty();
        }
    }
}

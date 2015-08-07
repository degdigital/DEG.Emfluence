using System.IO;
using System.Linq;
using DEG.Emfluence.Models;
using DEG.ServiceCore.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Emfluence.Tests
{
    [TestFixture]
    public class SaveContactErrorSerializationTests
    {
        private readonly SaveContactResponse _results;

        public SaveContactErrorSerializationTests()
        {
            var file = File.OpenText(@".\Data\SaveContactErrorResponse.json");

            _results = JsonHelper.Parse<SaveContactResponse>(file.ReadToEnd());
        }

        [Test]
        public void ContactDataParsed()
        {
            _results.Data.Should().NotBeNull();
        }

        [Test]
        public void ParsesSuccessAndCode()
        {
            _results.Success.Should().Be(0);
            _results.Code.Should().Be(301);
        }

        [Test]
        public void ParsesErrorsList()
        {
            _results.Errors.Should().HaveCount(1);
            _results.Errors.First().Should().Be("Email \"john.doe@example.com\" belongs to another record.");
        }

        [Test]
        public void ParsesContactId()
        {
            _results.Data.ContactId.Should().Be(456);
        }
    }
}

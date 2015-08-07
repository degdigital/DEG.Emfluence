using DEG.Emfluence.Models;
using DEG.ServiceCore.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Emfluence.Tests
{
    [TestFixture]
    public class ContactDataSerializationTests
    {
        [Test]
        public void SaveContactRequestExampleByEmail()
        {
            var expectedJson = @"{""email"":""new.record@example.com"",""firstName"":""John"",""groupIDs"":[123,456,789],""lastName"":""Doe""}";

            var data = new ContactData
                {
                    Email = "new.record@example.com",
                    FirstName = "John",
                    LastName = "Doe",
                    GroupIds = new[] {123, 456, 789}
                };

            var actualJson = JsonHelper.Stringify(data);

            actualJson.Should().Be(expectedJson);
        }

        [Test]
        public void SaveContactRequestExampleById()
        {
            var expectedJson = @"{""contactID"":123,""email"":""john.doe@example.com"",""firstName"":""John"",""lastName"":""Doe""}";
            var data = new ContactData
            {
                ContactId = 123,
                Email = "john.doe@example.com",
                FirstName = "John",
                LastName = "Doe"
            };

            var actualJson = JsonHelper.Stringify(data);

            actualJson.Should().Be(expectedJson);
        }
    }
}

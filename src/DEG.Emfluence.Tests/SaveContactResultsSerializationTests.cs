using System;
using System.IO;
using DEG.Emfluence.Models;
using DEG.ServiceCore.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Emfluence.Tests
{
    [TestFixture]
    public class SaveContactResultsSerializationTests
    {
        private readonly SaveContactResponse _results;

        public SaveContactResultsSerializationTests()
        {
            var file = File.OpenText(@".\Data\SaveContactResponse.json");

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
            _results.Success.Should().Be(1);
            _results.Code.Should().Be(0);
            _results.Errors.Should().BeNullOrEmpty();
        }

        [Test]
        public void ParsesErrorsList()
        {
            _results.Errors.Should().BeNullOrEmpty();
        }

        [Test]
        public void ParsesAddress()
        {
            _results.Data.Address1.Should().Be("123 Main St.");
            _results.Data.Address2.Should().Be("Ste. 105");
            _results.Data.City.Should().Be("Augusta");
            _results.Data.State.Should().Be("ME");
            _results.Data.ZipCode.Should().Be("86530");
            _results.Data.Country.Should().Be("USA");
        }

        [Test]
        public void ParsesNameTitleAndEmail()
        {
            _results.Data.FirstName.Should().Be("John");
            _results.Data.LastName.Should().Be("Doe");
            _results.Data.Title.Should().Be("Director of Widgets");
            _results.Data.Company.Should().Be("Acme Widgets, Inc.");
            _results.Data.Email.Should().Be("new.record@example.com");
        }

        [Test]
        public void ParsesCreatedAndModifiedDates()
        {
            _results.Data.DateAdded.Should().Be(new DateTime(2015, 04, 23, 20, 48, 10));
            _results.Data.DateModified.Should().Be(new DateTime(2015, 04, 23, 20, 48, 11));
        }

        [Test]
        public void ParsesHeld()
        {
            _results.Data.Held.Should().BeTrue();
            _results.Data.DateHeld.Should().Be(new DateTime(2015, 04, 23, 20, 48, 12));
        }

        [Test]
        public void ParsesSuppressed()
        {
            _results.Data.Suppressed.Should().BeTrue();
            _results.Data.DateSuppressed.Should().Be(new DateTime(2015, 04, 23, 20, 48, 13));
        }

        [Test]
        public void ParsesCustomFields()
        {
            _results.Data.CustomFields.Should().NotBeNull();

            _results.Data.CustomFields.Custom1.Label.Should().Be("Custom 1");
            _results.Data.CustomFields.Custom1.Value.Should().Be("alpha");

            _results.Data.CustomFields.Custom2.Label.Should().Be("Custom 2");
            _results.Data.CustomFields.Custom2.Value.Should().Be("beta");

            _results.Data.CustomFields.Custom3.Label.Should().Be("Custom 3");
            _results.Data.CustomFields.Custom3.Value.Should().Be("gamma");

            _results.Data.CustomFields.Custom4.Label.Should().Be("Custom 4");
            _results.Data.CustomFields.Custom4.Value.Should().Be("delta");
        }

        [Test]
        public void ParsesPhoneAndFax()
        {
            _results.Data.Phone.Should().Be("123-456-7890");
            _results.Data.Fax.Should().Be("234-567-8901");
        }

        [Test]
        public void ParsesDateOfBirth()
        {
            _results.Data.DateOfBirth.Should().Be(new DateTime(2001, 01, 01));
        }

        [Test]
        public void ParsesOriginalSource()
        {
            _results.Data.OriginalSource.Should().Be("Unknown");
        }
    }
}

using System;
using System.IO;
using System.Linq;
using DEG.Emfluence.Models;
using DEG.ServiceCore.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace DEG.Emfluence.Tests
{
    [TestFixture]
    public class SearchGroupResultsSerializationTests
    {
        private readonly SearchGroupsResponse _results;

        public SearchGroupResultsSerializationTests()
        {
            var file = File.OpenText(@".\Data\SearchGroupResponse.json");

            _results = JsonHelper.Parse<SearchGroupsResponse>(file.ReadToEnd());
        }

        [Test]
        public void ParsesSuccessAndCode()
        {
            _results.Success.Should().Be(1);
            _results.Code.Should().Be(0);
        }

        [Test]
        public void ParsesPaging()
        {
            _results.Data.Paging.Page.Should().Be(1);
            _results.Data.Paging.RecordsPerPage.Should().Be(20);
            _results.Data.Paging.TotalPages.Should().Be(1);
            _results.Data.Paging.TotalRecords.Should().Be(2);
        }

        [Test]
        public void ParsesFirstRecord()
        {
            var record = _results.Data.Records.First();
            record.FriendlyName.Should().Be("B2C Customers");
            record.DateAdded.Should().Be(new DateTime(2013, 02, 12, 2, 42, 0));
            record.Description.Should().Be("");
            record.GroupId.Should().Be(123);
            record.Private.Should().Be(1);
            record.DateModified.Should().Be(null);
            record.UserId.Should().Be(123);
            record.AutoResponseEmailId.Should().Be(null);
            record.TotalMembers.Should().Be(1000);
            record.ActiveMembers.Should().Be(500);
            record.DateLastEmailSent.Should().Be(new DateTime(2015, 02, 12, 0, 42, 0));
        }

        [Test]
        public void ParsesSecondRecord()
        {
            var record = _results.Data.Records.Skip(1).First();
            record.FriendlyName.Should().Be("B2B Customers");
            record.DateAdded.Should().Be(new DateTime(2014, 01, 21, 2, 57, 0));
            record.Description.Should().Be("");
            record.GroupId.Should().Be(456);
            record.Private.Should().Be(1);
            record.DateModified.Should().Be(null);
            record.UserId.Should().Be(null);
            record.AutoResponseEmailId.Should().Be(123);
            record.TotalMembers.Should().Be(1000);
            record.ActiveMembers.Should().Be(500);
            record.DateLastEmailSent.Should().Be(new DateTime(2015, 02, 12, 0, 42, 0));
        }
    }
}

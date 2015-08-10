using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using DEG.Emfluence.Models;
using DEG.ServiceCore;
using DEG.ServiceCore.Authentication;

namespace DEG.Emfluence
{
    public interface IEmfluenceService
    {
        SaveContactResponse SaveContact(ContactData contact);
        SearchGroupsResponse SearchGroups(SearchGroupsRequest request);
    }

    /// <summary>
    /// Simple interface for interacting with the Emfluence API v1: https://apidocs.emailer.emfluence.com/v1/
    /// </summary>
    public class EmfluenceService : ServiceBase, IEmfluenceService
    {
        protected readonly string BaseServiceUrl = "https://api.emailer.emfluence.com/v1/";

        public EmfluenceService(IServiceAuth auth) : base(auth) { }

        public SaveContactResponse SaveContact(ContactData contact)
        {
            var url = BaseServiceUrl + "contacts/save";
            return SubmitObject<SaveContactResponse, ContactData>(url, contact);
        }

        public SearchGroupsResponse SearchGroups(SearchGroupsRequest request)
        {
            var url = BaseServiceUrl + "groups/search";
            var criteria = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(request.GroupName))
                criteria.Add("groupName", request.GroupName);
            if (request.Status != SearchGroupStatus.Active)
                criteria.Add("status", request.Status.ToString());
            if (request.UserId.HasValue)
                criteria.Add("userID", request.UserId.Value.ToString(CultureInfo.InvariantCulture));
            if (request.Private.HasValue)
                criteria.Add("private", request.Private.Value ? "1" : "0");
            if (request.PageNumber.HasValue)
            {
                var page = request.PageNumber.Value;
                if (page < 1)
                    throw new ArgumentOutOfRangeException("page", page, "Page number must be a positive integer.");
                criteria.Add("page", page.ToString(CultureInfo.InvariantCulture));
            }
            if (request.PageSize.HasValue)
            {
                var size = request.PageSize.Value;
                if (size < 1 || size > 250)
                    throw new ArgumentOutOfRangeException("pageSize", size, "Page size must be a value from 1 to 250.");
                criteria.Add("rpp", size.ToString(CultureInfo.InvariantCulture));
            }

            var queryString = criteria.Select(x => string.Format("{0}={1}", x.Key, HttpUtility.UrlEncode(x.Value))).ToArray();
            if (queryString.Any())
                url += "?" + string.Join("&", queryString);

            return GetObject<SearchGroupsResponse>(url);
        }
    }
}

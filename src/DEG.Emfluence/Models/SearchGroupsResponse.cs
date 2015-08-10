using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DEG.Emfluence.Models
{
    [Serializable]
    [DataContract]
    public class SearchGroupsResponse
    {
        [DataMember(Name = "success")]
        public int Success { get; set; }
        [DataMember(Name = "code")]
        public int Code { get; set; }
        [DataMember(Name = "data")]
        public SearchGroupResponseData Data { get; set; }
    }

    [Serializable]
    [DataContract]
    public class SearchGroupResponseData
    {
        [DataMember(Name = "paging")]
        public SearchPagingResponse Paging { get; set; }
        [DataMember(Name = "records")]
        public IEnumerable<GroupData> Records { get; set; }
    }

    [Serializable]
    [DataContract]
    public class SearchPagingResponse
    {
        [DataMember(Name = "next", EmitDefaultValue = false)]
        public string Next { get; set; }
        [DataMember(Name = "page")]
        public int Page { get; set; }
        [DataMember(Name = "rpp")]
        public int RecordsPerPage { get; set; }
        [DataMember(Name = "totalPages")]
        public int TotalPages { get; set; }
        [DataMember(Name = "totalRecords")]
        public int TotalRecords { get; set; }
        [DataMember(Name = "prev", EmitDefaultValue = false)]
        public string Prev { get; set; }
    }
}

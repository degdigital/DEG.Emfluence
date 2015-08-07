using System;
using System.Runtime.Serialization;

namespace DEG.Emfluence.Models
{
    [Serializable]
    [DataContract]
    public class SaveContactResponse
    {
        [DataMember(Name = "success")]
        public int Success { get; set; }
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "errors")]
        public string[] Errors { get; set; }

        [DataMember(Name = "data")]
        public ContactData Data { get; set; }
    }
}

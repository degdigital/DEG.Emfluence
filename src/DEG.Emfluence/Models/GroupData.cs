using System;
using System.Runtime.Serialization;

namespace DEG.Emfluence.Models
{
    [Serializable]
    [DataContract]
    public class GroupData : DateAddedModifiedBase
    {
        /// <summary>
        /// Unique ID of a group
        /// </summary>
        [DataMember(Name = "groupID", EmitDefaultValue = false)]
        public int GroupId { get; set; }
        /// <summary>
        /// Name of group. Must be unique
        /// </summary>
        [DataMember(Name = "groupName", EmitDefaultValue = false)]
        public string GroupName { get; set; }
        /// <summary>
        /// One of: Active, Archived. Archived groups are hidden from results by default.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }
        /// <summary>
        /// Name displayed to contacts on preferences page. Defaults to groupName
        /// </summary>
        [DataMember(Name = "friendlyName", EmitDefaultValue = false)]
        public string FriendlyName { get; set; }
        /// <summary>
        /// Description of group. Displayed to contacts on preferences page.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }
        /// <summary>
        /// Do not display this group on contact preferences page
        /// </summary>
        [DataMember(Name = "private", EmitDefaultValue = false)]
        public int Private { get; set; }
        /// <summary>
        /// ID of email contacts will receive when added to group
        /// </summary>
        [DataMember(Name = "autoResponseEmailID", EmitDefaultValue = false)]
        public string AutoResponseEmailIdRaw { get; set; }
        public int? AutoResponseEmailId
        {
            get { int parsed; return int.TryParse(AutoResponseEmailIdRaw, out parsed) ? parsed : (int?)null; }
            set { AutoResponseEmailIdRaw = value.ToString(); }
        }

        [DataMember(Name = "totalMembers", EmitDefaultValue = false)]
        public string TotalMembersRaw { get; set; }
        public int? TotalMembers
        {
            get { int parsed; return int.TryParse(TotalMembersRaw, out parsed) ? parsed : (int?)null; }
            set { TotalMembersRaw = value.ToString(); }
        }

        [DataMember(Name = "activeMembers", EmitDefaultValue = false)]
        public string ActiveMembersRaw { get; set; }
        public int? ActiveMembers
        {
            get { int parsed; return int.TryParse(ActiveMembersRaw, out parsed) ? parsed : (int?)null; }
            set { ActiveMembersRaw = value.ToString(); }
        }

        [DataMember(Name = "userID", EmitDefaultValue = false)]
        public string UserIdRaw { get; set; }
        public int? UserId
        {
            get { int parsed; return int.TryParse(UserIdRaw, out parsed) ? parsed : (int?) null; }
            set { UserIdRaw = value.ToString(); }
        }

        [DataMember(Name = "dateLastEmailSent", EmitDefaultValue = false)]
        public string DateLastEmailSentRaw { get; set; }
        public DateTime? DateLastEmailSent
        {
            get { DateTime parsed; return DateTime.TryParse(DateLastEmailSentRaw, out parsed) ? parsed : (DateTime?)null; }
            set { DateLastEmailSentRaw = value.HasValue ? value.Value.ToString("yyyy-MM-dd HH:mm:ss") : null; }
        }

    }
}

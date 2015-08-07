using System;
using System.Runtime.Serialization;

namespace DEG.Emfluence.Models
{
    [Serializable]
    [DataContract]
    public class ContactData
    {
        /// <summary>
        /// Unique ID of a contact
        /// </summary>
        [DataMember(Name = "contactID", EmitDefaultValue = false)]
        public int ContactId { get; set; }
        /// <summary>
        /// ID of system user contact belongs to
        /// </summary>
        [DataMember(Name = "userID", EmitDefaultValue = false)]
        public int UserId { get; set; }
        [DataMember(Name = "groupIDs", EmitDefaultValue = false)]
        public int[] GroupIds { get; set; }
        
        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; set; }
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }
        [DataMember(Name = "company", EmitDefaultValue = false)]
        public string Company { get; set; }
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(Name = "dateOfBirth", EmitDefaultValue = false)]
        public string DateOfBirthRaw { get; set; }
        /// <summary>
        /// Full date of birth in yyyy-mm-dd format. To use only month and day, use 1900 as year
        /// </summary>
        public DateTime? DateOfBirth
        {
            get { DateTime parsed; return DateTime.TryParse(DateOfBirthRaw, out parsed) ? parsed : (DateTime?)null; }
            set { DateOfBirthRaw = value.HasValue ? value.Value.ToString("yyyy-MM-dd HH:mm:ss") : null; }
        }

        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public string Phone { get; set; }
        [DataMember(Name = "fax", EmitDefaultValue = false)]
        public string Fax { get; set; }

        [DataMember(Name = "address1", EmitDefaultValue = false)]
        public string Address1 { get; set; }
        [DataMember(Name = "address2", EmitDefaultValue = false)]
        public string Address2 { get; set; }
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }
        [DataMember(Name = "zipCode", EmitDefaultValue = false)]
        public string ZipCode { get; set; }
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        /// <summary>
        /// ID of record in client system
        /// </summary>
        [DataMember(Name = "customerID", EmitDefaultValue = false)]
        public string CustomerId { get; set; }
        /// <summary>
        /// Extra details about record (internal use)
        /// </summary>
        [DataMember(Name = "notes", EmitDefaultValue = false)]
        public string Notes { get; set; }
        public string Memo { get; set; }

        /// <summary>
        /// Bad email address (too many bounces)
        /// </summary>
        [DataMember(Name = "held", EmitDefaultValue = false)]
        public bool Held { get; set; }
        [DataMember(Name = "dateHeld", EmitDefaultValue = false)]
        public string DateHeldRaw { get; set; }
        public DateTime? DateHeld {
            get { DateTime parsed; return DateTime.TryParse(DateHeldRaw, out parsed) ? parsed : (DateTime?)null; }
            set { DateHeldRaw = value.HasValue ? value.Value.ToString("yyyy-MM-dd HH:mm:ss") : null; }
        }

        /// <summary>
        /// Opted out of receiving emails
        /// </summary>
        [DataMember(Name = "suppressed", EmitDefaultValue = false)]
        public bool Suppressed { get; set; }
        [DataMember(Name = "dateSuppressed", EmitDefaultValue = false)]
        public string DateSuppressedRaw { get; set; }
        public DateTime? DateSuppressed
        {
            get { DateTime parsed; return DateTime.TryParse(DateSuppressedRaw, out parsed) ? parsed : (DateTime?)null; }
            set { DateSuppressedRaw = value.HasValue ? value.Value.ToString("yyyy-MM-dd HH:mm:ss") : null; }
        }

        [DataMember(Name = "dateAdded", EmitDefaultValue = false)]
        public string DateAddedRaw { get; set; }
        public DateTime? DateAdded
        {
            get { DateTime parsed; return DateTime.TryParse(DateAddedRaw, out parsed) ? parsed : (DateTime?) null; }
            set { DateAddedRaw = value.HasValue ? value.Value.ToString("yyyy-MM-dd HH:mm:ss") : null; }
        }
        [DataMember(Name = "dateModified", EmitDefaultValue = false)]
        public string DateModifiedRaw { get; set; }
        public DateTime? DateModified
        {
            get { DateTime parsed; return DateTime.TryParse(DateModifiedRaw, out parsed) ? parsed : (DateTime?)null; }
            set { DateModifiedRaw = value.HasValue ? value.Value.ToString("yyyy-MM-dd HH:mm:ss") : null; }
        }

        [DataMember(Name = "customFields", EmitDefaultValue = false)]
        public CustomFields CustomFields { get; set; }

        /// <summary>
        /// Client-specified source of record
        /// </summary>
        [DataMember(Name = "originalSource", EmitDefaultValue = false)]
        public string OriginalSource { get; set; }

        [DataMember(Name = "content1", EmitDefaultValue = false)]
        public string Content1 { get; set; }
        [DataMember(Name = "content2", EmitDefaultValue = false)]
        public string Content2 { get; set; }
        [DataMember(Name = "content3", EmitDefaultValue = false)]
        public string Content3 { get; set; }

        /// <summary>
        /// Personal URL used with landing pages (must be unique)
        /// </summary>
        [DataMember(Name = "purl", EmitDefaultValue = false)]
        public string PersonalUrl { get; set; }

        /// <summary>
        /// Source IP of record
        /// </summary>
        [DataMember(Name = "ipaddress", EmitDefaultValue = false)]
        public string IpAddress { get; set; }
    }

    [DataContract]
    [Serializable]
    public class CustomFields
    {
        [DataMember(Name = "custom1", EmitDefaultValue = false)]
        public CustomFieldValue Custom1 { get; set; }
        [DataMember(Name = "custom2", EmitDefaultValue = false)]
        public CustomFieldValue Custom2 { get; set; }
        [DataMember(Name = "custom3", EmitDefaultValue = false)]
        public CustomFieldValue Custom3 { get; set; }
        [DataMember(Name = "custom4", EmitDefaultValue = false)]
        public CustomFieldValue Custom4 { get; set; }
        [DataMember(Name = "custom5", EmitDefaultValue = false)]
        public CustomFieldValue Custom5 { get; set; }
        [DataMember(Name = "custom6", EmitDefaultValue = false)]
        public CustomFieldValue Custom6 { get; set; }
    }

    [Serializable]
    [DataContract]
    public class CustomFieldValue
    {
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}
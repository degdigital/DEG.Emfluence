using System;
using System.Runtime.Serialization;

namespace DEG.Emfluence.Models
{
    [Serializable]
    [DataContract]
    public class DateAddedModifiedBase
    {
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
    }
}
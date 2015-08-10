namespace DEG.Emfluence.Models
{
    public class SearchGroupsRequest
    {
        public string GroupName { get; set; }
        public SearchGroupStatus Status { get; set; }
        public int? UserId { get; set; }
        public bool? Private { get; set; }

        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }

    public enum SearchGroupStatus
    {
        Active,
        Archived,
        All
    }
}

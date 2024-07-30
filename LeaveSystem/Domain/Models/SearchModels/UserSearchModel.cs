namespace LeaveSystem.Domain.Models.SearchModels
{
    public class UserSearchModel : BaseSearchModel
    {
        public string? Name { get; set; }

        public string? Email { get; set; }
    }
}
namespace LeaveSystem.Domain.Models.SearchModels
{
    public class BaseSearchModel
    {
        public int PageSize { get; set; } = 50;

        public int Page { get; set; } = 1;

        public string OrderBy { get; set; } = "CreateTime desc";
    }
}
namespace LeaveSystem.Domain.Entities
{
    public class Department : ModifyEntity
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
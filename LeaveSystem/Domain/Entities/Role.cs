namespace LeaveSystem.Domain.Entities
{
    public class Role : ModifyEntity
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
namespace LeaveSystem.Domain.Entities
{
    public class Function : ModifyEntity
    {
        public required string Name { get; set; }

        public required string ControllerName { get; set; }

        public required string ActionName { get; set; }

        public string Description { get; set; }
    }
}
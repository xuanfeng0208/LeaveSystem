namespace LeaveSystem.Domain.Dtos
{
    public class FunctionDto
    {
        public Guid ID { get; set; }

        public string? Name { get; set; }

        public string? ControllerName { get; set; }

        public string? ActionName { get; set; }

        public string? Description { get; set; }

        public string? CreateName { get; set; }

        public DateTime? CreateTime { get; set; }

        public string? UpdateName { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
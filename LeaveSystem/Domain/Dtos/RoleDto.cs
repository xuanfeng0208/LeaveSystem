namespace LeaveSystem.Domain.Dtos
{
    public class RoleDto
    {
        public Guid ID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<RoleFunctionDto>? RoleFunctionList { get; set; }
    }
}
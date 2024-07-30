namespace LeaveSystem.Domain.Dtos
{
    public class UserRoleDto
    {
        public Guid ID { get; set; }

        public IEnumerable<RoleDto>? RoleList { get; set; }
    }
}
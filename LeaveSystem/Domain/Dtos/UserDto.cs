namespace LeaveSystem.Domain.Dtos
{
    public class UserDto
    {
        public Guid ID { get; set; }

        public string? Name { get; set; }

        public string? CreateName { get; set; }

        public DateTime? CreateTime { get; set; }

        public string? UpdateName { get; set; }

        public DateTime? UpdateTime { get; set; }

        public Guid? DepartmentID { get; set; }

        public DepartmentDto? Department { get; set; }

        public IEnumerable<UserRoleDto>? UserRoleList { get; set; }
    }
}
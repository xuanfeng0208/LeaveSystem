namespace LeaveSystem.Domain.Dtos
{
    public class RoleFunctionDto
    {
        public Guid ID { get; set; }

        public IEnumerable<FunctionDto>? FunctionList { get; set; }
    }
}
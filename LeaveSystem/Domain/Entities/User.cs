using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveSystem.Domain.Entities
{
    public class User : ModifyEntity
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department? Department { get; set; }
    }
}
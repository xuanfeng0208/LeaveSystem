using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveSystem.Domain.Entities
{
    public class UserRole : ModifyEntity
    {
        public Guid UserID { get; set; }

        public Guid RoleID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
    }
}
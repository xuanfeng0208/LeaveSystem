using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveSystem.Domain.Entities
{
    public class RoleFunction : ModifyEntity
    {
        public Guid RoleID { get; set; }

        public Guid FunctionID { get; set; }

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        [ForeignKey("FunctionID")]
        public virtual Function Function { get; set; }
    }
}
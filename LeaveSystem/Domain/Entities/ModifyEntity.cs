using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveSystem.Domain.Entities
{
    public class ModifyEntity : BaseEntity
    {
        [MaxLength(50)]
        public required string CreateName { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public required DateTime CreateTime { get; set; }

        [MaxLength(50)]
        public string? UpdateName { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime? UpdateTime { get; set; }
    }
}
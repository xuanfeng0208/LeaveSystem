using System.ComponentModel.DataAnnotations;

namespace LeaveSystem.Domain.Entities
{
    public class Calendar : ModifyEntity
    {
        public DateTime Date { get; set; }

        public bool IsWork { get; set; }

        [MaxLength(50)]
        public string? Festival { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
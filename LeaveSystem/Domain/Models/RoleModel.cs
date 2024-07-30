using System.ComponentModel.DataAnnotations;

namespace LeaveSystem.Domain.Models
{
    public class RoleModel
    {
        public Guid? ID { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
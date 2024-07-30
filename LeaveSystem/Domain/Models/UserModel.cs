using System.ComponentModel.DataAnnotations;

namespace LeaveSystem.Domain.Models
{
    public class UserModel
    {
        public Guid? ID { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Password { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
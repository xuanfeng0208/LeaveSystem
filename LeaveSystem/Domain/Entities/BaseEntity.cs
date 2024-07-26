using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveSystem.Domain.Entities
{
    public class BaseEntity
    {
        [Column(Order = 0)]
        public int SequenceNo { get; set; }

        [Key, Column(Order = 1)]
        public Guid ID { get; set; }
    }
}
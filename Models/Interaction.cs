using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCRM.Models
{
    public class Interaction
    {
        [Key]
        [Required]
        public Guid InteractionGuid { get; set; } = Guid.NewGuid();

        [Required]
        public string Notes { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid CustomerGuid { get; set; }

        [ForeignKey("CustomerGuid")]
        public Customer Customer { get; set; }

        [Required]
        public Guid InteractionTypeGuid { get; set; }

        [ForeignKey("InteractionTypeGuid")]
        public InteractionType InteractionType { get; set; }
    }
}
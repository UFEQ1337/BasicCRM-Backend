using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BasicCRM.Models
{
    public class InteractionType
    {
        [Key]
        [Required]
        public Guid InteractionTypeGuid { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Interaction> Interactions { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace BasicCRM.DTOs
{
    public class InteractionTypeDto
    {
        public Guid InteractionTypeGuid { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
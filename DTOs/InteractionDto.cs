using System;
using System.ComponentModel.DataAnnotations;

namespace BasicCRM.DTOs
{
    public class InteractionDto
    {
        public Guid InteractionGuid { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid CustomerGuid { get; set; }

        [Required]
        public Guid InteractionTypeGuid { get; set; }
    }
}
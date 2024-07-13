using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCRM.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public Guid ContactGuid { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        public Guid CustomerGuid { get; set; }

        [ForeignKey("CustomerGuid")]
        public Customer Customer { get; set; }
    }
}
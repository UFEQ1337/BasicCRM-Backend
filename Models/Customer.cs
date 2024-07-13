using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace BasicCRM.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public Guid CustomerGuid { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Interaction> Interactions { get; set; }
    }
}

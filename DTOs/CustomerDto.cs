using System.ComponentModel.DataAnnotations;

namespace BasicCRM.DTOs
{
    public class CustomerDto
    {
        public Guid CustomerGuid { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BasicCRM.DTOs
{
    public class ContactDto
    {
        public Guid ContactGuid { get; set; }

        [Required] [StringLength(100)] public string Name { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [Phone] public string Phone { get; set; }

        [Required] public Guid CustomerGuid { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace BasicCRM.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Role { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace BasicCRM.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        public string Password { get; set; }
    }
}
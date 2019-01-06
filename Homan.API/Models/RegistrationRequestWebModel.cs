using System.ComponentModel.DataAnnotations;

namespace Homan.API.Models
{
    public class RegistrationRequestWebModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
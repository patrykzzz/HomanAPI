using System.ComponentModel.DataAnnotations;

namespace Homan.API.Models
{
    public class LoginRequestWebModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
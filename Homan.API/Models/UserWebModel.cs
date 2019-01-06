using System;
using System.ComponentModel.DataAnnotations;

namespace Homan.API.Models
{
    public class UserWebModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
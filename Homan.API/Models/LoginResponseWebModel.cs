using System;

namespace Homan.API.Models
{
    public class LoginResponseWebModel
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
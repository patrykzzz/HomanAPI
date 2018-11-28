using Microsoft.AspNetCore.Identity;
using System;

namespace Homan.DAL.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
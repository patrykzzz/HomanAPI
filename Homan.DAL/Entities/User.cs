using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Homan.DAL.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<HomeSpace> UserHomeSpaces { get; set; }
    }
}
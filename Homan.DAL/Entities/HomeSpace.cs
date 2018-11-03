using System;
using System.Collections.Generic;

namespace Homan.DAL.Entities
{
    public class HomeSpace
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserInHomeSpace> HomeSpaceUsers { get; set; }
        public virtual ICollection<HomeSpaceItem> HomeSpaceItems { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Homan.DAL.Entities
{
    public class HomeSpace
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<UserInHomeSpace> HomeSpaceUsers { get; set; }
        public virtual ICollection<HomeSpaceItemList> HomeSpaceItems { get; set; }
    }
}
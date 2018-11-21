using System;
using System.Collections.Generic;

namespace Homan.DAL.Entities
{
    public class HomeSpaceItemList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        public Guid HomeSpaceId { get; set; }
        public virtual HomeSpace HomeSpace { get; set; }
        public virtual ICollection<HomeSpaceItem> HomeSpaceItems { get; set; }
    }
}
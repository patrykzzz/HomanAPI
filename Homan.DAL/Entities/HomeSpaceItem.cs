using System;

namespace Homan.DAL.Entities
{
    public class HomeSpaceItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid HomeSpaceListId { get; set; }
        public virtual HomeSpaceItemList HomeSpaceList{ get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
using System;

namespace Homan.DAL.Entities
{
    public class HomeSpaceItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public ItemType ItemType { get; set; }
        
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        public Guid HomeSpaceId { get; set; }
        public virtual HomeSpace HomeSpace { get; set; }
    }
}
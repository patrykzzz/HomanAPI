using System;

namespace Homan.BLL.Models
{
    public class HomeSpaceItemModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public ItemTypeModel ItemType { get; set; }
        public Guid HomeSpaceId { get; set; }
        public UserModel User { get; set; }
        public Guid? UserId { get; set; }
    }
}
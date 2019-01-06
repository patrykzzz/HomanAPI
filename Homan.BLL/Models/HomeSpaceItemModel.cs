using System;

namespace Homan.BLL.Models
{
    public class HomeSpaceItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; }
    }
}
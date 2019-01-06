using System;

namespace Homan.API.Models
{
    public class HomeSpaceItemWebModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid HomeSpaceId { get; set; }
        public Guid UserId { get; set; }
    }
}
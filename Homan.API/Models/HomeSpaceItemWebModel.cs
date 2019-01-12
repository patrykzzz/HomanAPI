using System;
using System.ComponentModel.DataAnnotations;

namespace Homan.API.Models
{
    public class HomeSpaceItemWebModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public ItemTypeWebModel ItemType { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public Guid HomeSpaceId { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
    }
}
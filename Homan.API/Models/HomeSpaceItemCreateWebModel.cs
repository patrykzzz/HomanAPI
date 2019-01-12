using System;
using System.ComponentModel.DataAnnotations;

namespace Homan.API.Models
{
    public class HomeSpaceItemCreateWebModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public ItemTypeWebModel ItemType { get; set; }
        [Required]
        public Guid HomeSpaceId { get; set; }
    }
}
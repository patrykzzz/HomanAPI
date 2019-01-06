using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Homan.API.Models
{
    public class HomeSpaceWebModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }

        public Guid OwnerId { get; set; }
        public IEnumerable<UserWebModel> HomeSpaceUsers { get; set; }
        public IEnumerable<HomeSpaceItemWebModel> HomeSpaceItems { get; set; }
    }
}
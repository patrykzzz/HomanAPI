using System;
using System.Collections.Generic;

namespace Homan.BLL.Models
{
    public class HomeSpaceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Guid OwnerId { get; set; }
        public IEnumerable<UserModel> HomeSpaceUsers { get; set; }
        public IEnumerable<HomeSpaceItemModel> HomeSpaceItems { get; set; }
    }
}
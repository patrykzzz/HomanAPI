using System;

namespace Homan.API.Models
{
    public class HomeSpaceUserRemoveWebModel
    {
        public Guid HomeSpaceId { get; set; }
        public Guid UserToRemoveId { get; set; }
    }
}
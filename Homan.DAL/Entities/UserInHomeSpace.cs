using System;

namespace Homan.DAL.Entities
{
    public class UserInHomeSpace
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid HomeSpaceId { get; set; }
        public virtual HomeSpace HomeSpace { get; set; }
    }
}
using System;

namespace Homan.BLL.Models
{
    public class HomeSpaceInvitationModel
    {
        public Guid HomeSpaceId { get; set; }
        public Guid InvitingUserId { get; set; }
        public string UserEmail { get; set; }
    }
}
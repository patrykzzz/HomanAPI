using System;
using System.ComponentModel.DataAnnotations;

namespace Homan.API.Models
{
    public class HomeSpaceInvitationWebModel
    {
        [Required]
        public Guid HomeSpaceId { get; set; }
        [Required, EmailAddress]
        public string UserEmail { get; set; }
    }
}
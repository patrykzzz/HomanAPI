﻿using System;

namespace Homan.BLL.Models
{
    public class LoginResponseModel
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
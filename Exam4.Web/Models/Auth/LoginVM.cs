﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exam4.Web.Models.Auth
{
    public class LoginVM
    {
        [EmailAddress]
        public string Email { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}

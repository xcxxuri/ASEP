using System;
using System.ComponentModel.DataAnnotations;

namespace Authentication.ApplicationCore.Models
{
	public class LoginModel
	{
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
	}
}


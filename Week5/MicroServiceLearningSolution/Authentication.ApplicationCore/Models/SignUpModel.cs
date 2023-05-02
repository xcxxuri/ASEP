using System;
using System.ComponentModel.DataAnnotations;

namespace Authentication.ApplicationCore.Models
{
	public class SignUpModel
	{
        // firstname, lastname, email, password, confirm password
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required ]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

	}
}


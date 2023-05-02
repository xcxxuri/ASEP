using System;
using Microsoft.AspNetCore.Identity;

namespace Authentication.ApplicationCore.Models
{
	public class ApplicationUser : IdentityUser
	{
        // ApplicationUser is use to inherit from IdentityUser
        public string FirstName { get; set; }
        public string LastName { get; set; }
	}
}


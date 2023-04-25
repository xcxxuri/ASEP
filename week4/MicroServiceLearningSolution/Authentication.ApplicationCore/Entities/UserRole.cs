using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.ApplicationCore.Entities
{
	public class UserRole
	{   
        [Required]
        public int Id { get; set; }
        [ForeignKey("Account")]
        public int UserId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
	}
}


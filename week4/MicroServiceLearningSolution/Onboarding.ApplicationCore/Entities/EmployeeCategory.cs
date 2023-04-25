using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Entities
{
	public class EmployeeCategory
	{
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string? Description { get; set; }
	}
}


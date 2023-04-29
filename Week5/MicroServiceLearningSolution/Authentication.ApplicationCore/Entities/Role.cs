using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.ApplicationCore.Entities
{
	public class Role
	{
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(129)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

	}
}


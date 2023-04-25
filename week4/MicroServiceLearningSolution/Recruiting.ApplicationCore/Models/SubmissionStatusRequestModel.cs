using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.ApplicationCore.Models
{
	public class SubmissionStatusRequestModel
	{
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(512)")]
        public string Description { get; set; }
	}
}


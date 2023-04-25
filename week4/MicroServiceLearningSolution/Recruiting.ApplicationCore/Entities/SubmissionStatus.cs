using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.ApplicationCore.Entities
{
    public class SubmissionStatus
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(512)")]
        public string Description { get; set; }
    }
}


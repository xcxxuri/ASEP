using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Models
{
    public class InterviewTypeRequestModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Description { get; set; }
    }
}


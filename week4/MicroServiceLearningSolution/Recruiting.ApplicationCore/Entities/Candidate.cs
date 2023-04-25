using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recruiting.ApplicationCore.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        // Data Annonitation Not NULL
        [Required]
        // Data Annonitation NVARCHAR(128)
        [Column(TypeName = "nvarchar(128)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string? MiddleName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(256)")]
        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        public string Email { get; set; }
        // Data Annonitation NVARCHAR(MAX)
        [Column(TypeName = "nvarchar(max)")]
        public string ResumeURL { get; set; }

    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Entities
{
    public class EmployeeStatus
    {
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string? Description { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string? ABBR { get; set; }
    }
}


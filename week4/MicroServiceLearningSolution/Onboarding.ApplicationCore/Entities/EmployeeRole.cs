using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Entities
{
    public class EmployeeRole
    {
        [Required]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? EmployeeRoleName { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string? ABBR { get; set; }
    }
}


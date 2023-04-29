using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string? MiddleName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(9)")]
        public string SSN { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("EmployeeCategory")]
        public int EmployeeCategoryId { get; set; }
        [ForeignKey("EmployeeStatus")]
        public int EmployeeStatusId { get; set; }
        [ForeignKey("EmployeeRole")]
        public int EmployeeRoleId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        public string Email { get; set; }
    }
}


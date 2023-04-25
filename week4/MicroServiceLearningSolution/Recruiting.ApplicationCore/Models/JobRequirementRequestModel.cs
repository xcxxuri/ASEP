using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.ApplicationCore.Models
{
    public class JobRequirementRequestModel
    {
        public int Id { get; set; }
        public int NumberOfPositions { get; set; }
        [Column(TypeName = "nvarchar(512)")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? HiringManagerId { get; set; }
        public string? HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? ClosedReason { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? JobCategory { get; set; }
        public string? EmployeeType { get; set; }
    }
}


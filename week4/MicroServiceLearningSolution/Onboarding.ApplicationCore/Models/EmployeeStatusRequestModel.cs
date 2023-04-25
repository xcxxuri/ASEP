using System;
namespace Onboarding.ApplicationCore.Models
{
    public class EmployeeStatusRequestModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? ABBR { get; set; }
    }
}


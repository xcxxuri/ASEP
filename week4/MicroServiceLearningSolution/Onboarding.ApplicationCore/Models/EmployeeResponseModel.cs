﻿using System;
namespace Onboarding.ApplicationCore.Models
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeCategoryId { get; set; }
        public int EmployeeStatusId { get; set; }
        public int EmployeeRoleId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}


﻿using System;
namespace ApplicationCore.Entities
{
    public class Employee
    {
        public Employee()
        {
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int DepId { get; set; }

        // navigation property: use to help reference values from related table
        public Departments department { get; set; }
    }
}


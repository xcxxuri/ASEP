using System;
namespace ApplicationCore.Entities
{
    public class Employees
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }

        // nevigational property: use to help reference values from related table
        public Departments? departments { get; set; }
    }
}


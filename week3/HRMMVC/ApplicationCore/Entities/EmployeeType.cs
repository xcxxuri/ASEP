using System;
namespace ApplicationCore.Entities
{
    /*public enum HiredType
    {
        FullTime = 1,
        Contractor = 2,
        PartTime,
        Intern
    }*/
    public class EmployeeType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = "";

        public List<EmployeeRequirementType> EmployeeRequirementTypes { get; set; }
    }
}


using System;
namespace ConsoleToWeb.SOLID
{
    public class SRP
    {
        //  SRP: Single Responsibility Principle

        // To apply SRP, we should consider the following:put Constructor into out Repository and put Run() into Services. so the SRP class will only contain the properties.
        public int Id { get; set; }
        public string Name { get; set; }

        // Repository
        public SRP(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Services
        public void Run()
        {
            Console.WriteLine(Name + " " + Id);
        }
    }
}


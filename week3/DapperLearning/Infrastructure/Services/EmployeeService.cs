using System;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
	public class EmployeeService
	{
        EmployeeRepository employeeRepository;

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }

        // try the Insert method from the repository
        public void AddEmployee()
        {
            Employees e = new Employees();
            Console.Write("Enter Insert Employee First Name:  ");
            e.FirstName = Console.ReadLine();
            Console.Write("Enter Insert Employee Last Name:  ");
            e.LastName = Console.ReadLine();
            Console.Write("Enter Insert Employee Salary:  ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Insert Employee Department Id:  ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            // reflects the number of rows affected
            if (employeeRepository.Insert(e) > 0)
            {
                Console.WriteLine("Employee Added Successfully");
            }
            else
            {
                Console.WriteLine("Employee Not Added");
            }
        }

        // try the DeleteById method from the repository
        public void DeleteEmployee()
        {
            Console.Write("Enter Delete Employee Id:  ");
            // use Convert.ToInt32 to convert the input string to int
            int id = Convert.ToInt32(Console.ReadLine());
            if (employeeRepository.DeleteById(id) > 0)
            {
                Console.WriteLine("Employee Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Employee Not Deleted");
            }
        }

        // try the GetAll method from the repository
        public void GetAllEmployees()
        {
            IEnumerable<Employees> employees = employeeRepository.GetAll();
            foreach (var item in employees)
            {
                Console.WriteLine($"Id: {item.Id} \t Name: {item.FirstName} \t Salary: {item.Salary} \t Department Id: {item.DeptId}");
            }
        }

        // // try the GetById method from the repository
        // public void GetEmployeeById()
        // {
        //     Console.Write("Enter Employee Id:  ");
        //     // use Convert.ToInt32 to convert the input string to int
        //     int id = Convert.ToInt32(Console.ReadLine());
        //     var item = employeeRepository.GetById(id);
        //     if (item != null)
        //     {
        //         Console.WriteLine($"Id: {item.Id} \t Name: {item.FirstName} \t Salary: {item.Salary} \t Department Id: {item.DeptId}");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Employee Not Found");
        //     }
        // }

        // try the GetById method from the repository
        public Employees GetEmployeeById()
        {
            Console.Write("Enter Employee Id:  ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employees employees = employeeRepository.GetById(id);
            Console.WriteLine($"Id: {employees.Id} \t Name: {employees.FirstName} \t Salary: {employees.Salary} \t Department Id: {employees.DeptId}");
            return employeeRepository.GetById(id);
        }

        // try the Update method from the repository
        public void UpdateEmployee()
        {
            Employees e = new Employees();
            Console.Write("Enter Update Employee Id:  ");
            e.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Update Employee First Name:  ");
            e.FirstName = Console.ReadLine();
            Console.Write("Enter Update Employee Last Name:  ");
            e.LastName = Console.ReadLine();
            Console.Write("Enter Update Employee Salary:  ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Update Employee Department Id:  ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            // reflects the number of rows affected
            if (employeeRepository.Update(e) > 0)
            {
                Console.WriteLine("Employee Updated Successfully");
            }
            else
            {
                Console.WriteLine("Employee Not Updated");
            }
        }

	}
}


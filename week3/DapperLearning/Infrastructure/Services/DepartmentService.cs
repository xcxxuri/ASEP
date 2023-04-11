using System;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    // the service use the methods from the repository
    public class DepartmentService
    {
        DepartmentRepository departmentrepository;
        public DepartmentService()
        {
            departmentrepository = new DepartmentRepository();
        }

        // try the Insert method from the repository
        public void AddDepartment()
        {
            Departments d = new Departments();
            Console.Write("Enter Insert Department Name:  ");
            d.DeptName = Console.ReadLine();
            Console.Write("Enter Insert Department Location:  ");
            d.Location = Console.ReadLine();

            // reflects the number of rows affected

            if (departmentrepository.Insert(d) > 0)
            {
                Console.WriteLine("Department Added Successfully");
            }
            else
            {
                Console.WriteLine("Department Not Added");
            }
        }

        // try the DeleteById method from the repository
        public void DeleteDepartment()
        {
            Console.Write("Enter Delete Department Id:  ");
            // use Convert.ToInt32 to convert the input string to int
            int id = Convert.ToInt32(Console.ReadLine());
            if (departmentrepository.DeleteById(id) > 0)
            {
                Console.WriteLine("Department Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Department Not Deleted");
            }
        }

        // try the GetAll method from the repository
        public void GetAllDepartments()
        {
            IEnumerable<Departments> departments = departmentrepository.GetAll();
            foreach (var item in departments)
            {
                Console.WriteLine($"Id: {item.Id} \t Name: {item.DeptName} \t Location: {item.Location}");
            }
        }

        // // try the GetById method from the repository
        // public void GetDepartmentById()
        // {
        //     Console.Write("Enter Department Id You Want to Get:  ");
        //     int id = Convert.ToInt32(Console.ReadLine());
        //     var item = departmentrepository.GetById(id);
        //     if (item != null)
        //     {
        //         Console.WriteLine($"Id: {item.Id} \t Name: {item.DeptName} \t Location: {item.Location}");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Department Not Found");
        //     }
        // }

        // try the GetById method from the repository
        public Departments GetDepartmentById()
        {
            Console.Write("Enter Department Id You Want to Get:  ");
            int id = Convert.ToInt32(Console.ReadLine());
            Departments department = departmentrepository.GetById(id);
            Console.WriteLine($"Id: {department.Id} \t Name: {department.DeptName} \t Location: {department.Location}");
            return department;
        }

        // try the Update method from the repository
        public void UpdateDepartment()
        {
            // create a new department object
            Departments d = new Departments();

            Console.Write("Enter Update Department Id:  ");
            d.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Update Department Name:  ");
            d.DeptName = Console.ReadLine();
            Console.Write("Enter Update Department Location:  ");
            d.Location = Console.ReadLine();

            // use Update method from the repository to update the department
            if (departmentrepository.Update(d) > 0)
            {
                Console.WriteLine("Department Updated Successfully");
            }
            else
            {
                Console.WriteLine("Department Not Updated");
            }
        }
    }
}


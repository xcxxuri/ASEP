using System;
using Infrastructure.Services;

namespace DapperLearning.Menu
{
    public class MenuSelection
    {
        DepartmentService departmentService = new DepartmentService();
        EmployeeService employeeService = new EmployeeService();
        public MenuSelection()
        {
            employeeService = new EmployeeService();
            departmentService = new DepartmentService();

        }
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Employee Management System");
            Console.WriteLine("Please select an option from the menu below:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Delete Employee");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Get Employee By Id");
            Console.WriteLine("5. Get All Employees");
            Console.WriteLine("6. Add Department");
            Console.WriteLine("7. Delete Department");
            Console.WriteLine("8. Update Department");
            Console.WriteLine("9. Get Department By Id");
            Console.WriteLine("10. Get All Departments");
            Console.WriteLine("11. Exit");
        }

        public void Run()
        {
            // use while loop to keep the menu running until the user choose to exit
            while (true)
            {
                DisplayMenu();
                var choice = InputChoice();
                // switch statement to handle the user's choice
                switch (choice)
                {
                    case 1:
                        employeeService.AddEmployee();
                        break;
                    case 2:
                        employeeService.DeleteEmployee();
                        break;
                    case 3:
                        employeeService.UpdateEmployee();
                        break;
                    case 4:
                        employeeService.GetEmployeeById();
                        break;
                    case 5:
                        employeeService.GetAllEmployees();
                        break;
                    case 6:
                        departmentService.AddDepartment();
                        break;
                    case 7:
                        departmentService.DeleteDepartment();
                        break;
                    case 8:
                        departmentService.UpdateDepartment();
                        break;
                    case 9:
                        departmentService.GetDepartmentById();
                        break;
                    case 10:
                        departmentService.GetAllDepartments();
                        break;
                    case 11:
                        Console.WriteLine("Thank you for using the Employee Management System");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }


            // var choice = InputChoice();

            // // switch statement to handle the user's choice
            // switch (choice)
            // {
            //     case 1:
            //         employeeService.AddEmployee();
            //         break;
            //     case 2:
            //         employeeService.DeleteEmployee();
            //         break;
            //     case 3:
            //         employeeService.UpdateEmployee();
            //         break;
            //     case 4:
            //         employeeService.GetEmployeeById();
            //         break;
            //     case 5:
            //         employeeService.GetAllEmployees();
            //         break;
            //     case 6:
            //         departmentService.AddDepartment();
            //         break;
            //     case 7:
            //         departmentService.DeleteDepartment();
            //         break;
            //     case 8:
            //         departmentService.UpdateDepartment();
            //         break;
            //     case 9:
            //         departmentService.GetDepartmentById();
            //         break;
            //     case 10:
            //         departmentService.GetAllDepartments();
            //         break;
            //     case 11:
            //         Console.WriteLine("Thank you for using the Employee Management System");
            //         break;
            //     default:
            //         Console.WriteLine("Invalid choice");
            //         break;
            // }
        }

        public int InputChoice()
        {
            var choice = 0;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid choice");
            }
            return choice;
        }
    }
}


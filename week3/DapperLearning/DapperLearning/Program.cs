using ApplicationCore.Entities;
using DapperLearning.Menu;
using Infrastructure.Services;

namespace DapperLearning;

public class Program
{
    public static void Main()
    {
        // // List<Employees> employees = new List<Employees>();
        // DepartmentService departmentService = new DepartmentService();
        // departmentService.GetAllDepartments();
        // // departmentService.AddDepartment();
        // // departmentService.DeleteDepartment();
        // // departmentService.GetDepartmentById();
        // // departmentService.UpdateDepartment();

        // EmployeeService employeeService = new EmployeeService();
        // employeeService.AddEmployee();
        // employeeService.AddEmployee();
        
        // employeeService.DeleteEmployee();
        // employeeService.UpdateEmployee();
        // employeeService.GetEmployeeById();

        // employeeService.GetAllEmployees();

        MenuSelection menu = new MenuSelection();
        menu.Run();

    }
}

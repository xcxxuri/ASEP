using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public interface IEmployeeService
    {
        void AddEmployee();
        void DeleteEmployee();
        void GetAllEmployees();
        Employees GetEmployeeById();
        void UpdateEmployee();
    }
}
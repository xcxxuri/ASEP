using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public interface IDepartmentService
    {
        void AddDepartment();
        void DeleteDepartment();
        void GetAllDepartments();
        Departments GetDepartmentById();
        void UpdateDepartment();
    }
}

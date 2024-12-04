using Slider.DAL.Models;

namespace Slider.BS.Services.Abstractions;

public interface IDepartmentService
{
    Task<List<Department>> GetAllDepartments();
    Task<Department> GetDepartmentById(int id);
    Task<int> CreateDepartment(Department department);
    Task<int> UpdateDepartment(int id, Department newDepartment);
    Task<int> DeleteDepartment(int id);
}

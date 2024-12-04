using Microsoft.EntityFrameworkCore;
using Slider.BS.Services.Abstractions;
using Slider.DAL.Contexts;
using Slider.DAL.Models;

namespace Slider.BS.Services.Implements;

public class DepartmentService : IDepartmentService
{
    private readonly SliderDbContext _context;
    public DepartmentService(SliderDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CreateDepartment(Department department)
    {
        await _context.Departments.AddAsync(department);
        int res = await _context.SaveChangesAsync();
        return res;
    }

    public async Task<int> DeleteDepartment(int id)
    {
        Department department = await GetDepartmentById(id);
        department.IsDeleted = true;
        int res = await _context.SaveChangesAsync();
        return res;
    }

    public async Task<List<Department>> GetAllDepartments()
    {
        List<Department> departments = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync();
        return departments;
    }

    public async Task<Department> GetDepartmentById(int id)
    {
        Department? department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

        if (department == null) throw new Exception("Invalid id");
        return department;
    }

    public async Task<int> UpdateDepartment(int id, Department newDepartment)
    {
        Department department = await GetDepartmentById(id);
        department.Name = newDepartment.Name;
        int res = await _context.SaveChangesAsync();
        return res;
    }
}

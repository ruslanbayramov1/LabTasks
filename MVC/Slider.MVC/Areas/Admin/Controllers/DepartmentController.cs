using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slider.BS.Services.Abstractions;
using Slider.DAL.Models;

namespace Slider.MVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin, Doctor")]
public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;
    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IActionResult> Index()
    {
        List<Department> departments = await _departmentService.GetAllDepartments();
        return View(departments);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Department department)
    {
        await _departmentService.CreateDepartment(department);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (!id.HasValue) return NotFound();

        await _departmentService.DeleteDepartment(id.Value);
        return RedirectToAction(nameof(Index));
    }
}

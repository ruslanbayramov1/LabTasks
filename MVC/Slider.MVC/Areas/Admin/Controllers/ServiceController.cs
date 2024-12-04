using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slider.BS.Services.Abstractions;
using Slider.DAL.Contexts;
using Slider.DAL.Models;
using Slider.MVC.ViewModels.Services;

namespace Slider.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class ServiceController : Controller
{
    private readonly SliderDbContext _context;
    private readonly IServiceService _serviceService;
    public ServiceController(IServiceService serviceService, SliderDbContext context)
    {
        _serviceService = serviceService;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        List<Service> services = await _serviceService.GetAllServices();
        return View(services);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Departments = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ServiceItemVM vm)
    {
        if (!ModelState.IsValid)
        { 
            return View(vm);
        }

        Service service = new Service
        { 
            Description = vm.Description,
            Title = vm.Title,
            Icon = vm.Icon,
            DepartmentId = vm.DepartmentId
        };
        await _serviceService.CreateService(service);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (!id.HasValue) return BadRequest();
        Service service = await _serviceService.GetServiceById(id.Value);
        ViewBag.Departments = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync();
        return View(service);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int? id, ServiceItemVM vm)
    {
        if (!id.HasValue) return BadRequest();
        Service service = new Service
        { 
            Title = vm.Title,
            Description = vm.Description,
            DepartmentId = vm.DepartmentId,
            Icon = vm.Icon
        };
        await _serviceService.UpdateService(id.Value, service);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (!id.HasValue) return BadRequest();

        await _serviceService.DeleteService(id.Value);
        return RedirectToAction(nameof(Index));
    }
}

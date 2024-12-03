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
        ViewBag.Departments = await _context.Departments.ToListAsync();
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

    public async Task<IActionResult> Update()
    {
        return View();
    }

    public async Task<IActionResult> Delete()
    {
        return View();
    }
}

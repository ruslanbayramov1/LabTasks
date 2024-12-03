using Microsoft.AspNetCore.Mvc;
using Slider.DAL.Models;

namespace Slider.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class DepartmentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

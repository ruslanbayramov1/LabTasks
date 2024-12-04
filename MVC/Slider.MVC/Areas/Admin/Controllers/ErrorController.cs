using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slider.MVC.ViewModels.Errors;

namespace Slider.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : Controller
    {
        public async Task<IActionResult> Index(int? code, string? message)
        {
            ErrorVM vm = new ErrorVM();
            vm.Message = message;
            vm.Code = code.Value;
            return View(vm);
        }
    }
}

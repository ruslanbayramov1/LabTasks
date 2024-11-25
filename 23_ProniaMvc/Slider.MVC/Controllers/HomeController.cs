using Microsoft.AspNetCore.Mvc;
using Slider.BS.Services.Abstractions;
using Slider.DAL.Models;
using Slider.MVC.ViewModels.Commons;
using Slider.MVC.ViewModels.Sliders;

namespace Slider.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        public HomeController(ISliderService service)
        {
            _sliderService = service;
        }
        public async Task<IActionResult> Index()
        {
            List<SliderItem> sliders = await _sliderService.GetAllSliderItems();
            HomeVM vm = new HomeVM();
            vm.Sliders = sliders;
            return View(vm);
        }
    }
}

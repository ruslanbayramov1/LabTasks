using Microsoft.AspNetCore.Mvc;
using Slider.BS.Services.Abstractions;
using Slider.DAL.Models;
using Slider.MVC.ViewModels.Commons;
using Slider.MVC.ViewModels.Services;

namespace Slider.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IServiceService _serviceService;
        public HomeController(ISliderService service, IServiceService serviceService)
        {
            _sliderService = service;
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            List<SliderItem> sliders = await _sliderService.GetAllSliderItems();
            List<Service> services = await _serviceService.GetAllServices();
            List<ServiceItemVM> serviceItems = services.Select(x => new ServiceItemVM {
                Title = x.Title,
                Description = x.Description,
                Icon = x.Icon
            }).ToList();

            HomeVM vm = new HomeVM();
            vm.Sliders = sliders;
            vm.Services = services;
            return View(vm);
        }

        public IActionResult Denied()
        { 
            return View();
        }
    }
}

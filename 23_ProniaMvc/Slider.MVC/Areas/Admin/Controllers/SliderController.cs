using Microsoft.AspNetCore.Mvc;
using Slider.BS.Commonsl;
using Slider.BS.Extensions;
using Slider.BS.Services.Abstractions;
using Slider.DAL.Models;
using Slider.MVC.ViewModels.Sliders;

namespace Slider.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class SliderController : Controller
{
    private readonly ISliderService _sliderService;
    private readonly IWebHostEnvironment _env;
    public SliderController(ISliderService service, IWebHostEnvironment env)
    {
        _sliderService = service;
        _env = env;
    }

    public async Task<IActionResult> Index()
    {
        List<SliderItem> items = await _sliderService.GetAllSliderItems();
        return View(items);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SliderCreateVM vm)
    {
        if (vm.File != null)
        {
            if (!vm.File.IsValidType(FileType.type))
                ModelState.AddModelError("File", "The type of file must be an " + FileType.type);

            if (!vm.File.IsValidSize(400))
                ModelState.AddModelError("File", $"The size of file must be less than {FileType.kb} kb");
        }
        if (!ModelState.IsValid)
        { 
            return View(vm);
        }

        string filePath = Path.Combine(_env.WebRootPath, "imgs", "sliders");
        SliderItem item = new SliderItem
        {
            Title = vm.Title,
            ShortDesc = vm.ShortDesc,
            ImageUrl = vm.File!.Upload(filePath).Result,
            Offer = vm.Offer,
        };
        
        await _sliderService.Create(item);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id == null) return BadRequest();

        SliderItem? item = await _sliderService.GetSliderItemById((int)id);
        if (item == null) return NotFound();

        ViewBag.Slider = item;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(int? id, SliderUpdateVM vm)
    {
        if (id == null) return BadRequest();

        SliderItem? slider = await _sliderService.GetSliderItemById((int)id);
        if (slider == null) return NotFound();

        if (vm.File != null)
        {
            if (!vm.File.IsValidType(FileType.type))
                ModelState.AddModelError("File", "The type of file must be an " + FileType.type);

            if (!vm.File.IsValidSize(400))
                ModelState.AddModelError("File", $"The size of file must be less than {FileType.kb} kb");
        }
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        SliderItem item = new SliderItem
        {
            Title = vm.Title,
            ShortDesc = vm.ShortDesc,
            Offer = vm.Offer,
        };
        if (vm.File != null)
        { 
            string filePath = Path.Combine(_env.WebRootPath, "imgs", "sliders");
            string fullPath = Path.Combine(filePath, slider.ImageUrl);
            string newFileName = await vm.File.Upload(filePath, slider.ImageUrl);
            item.ImageUrl = newFileName;
        }
        item.ImageUrl ??= slider.ImageUrl;

        await _sliderService.Update((int)id, item);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return BadRequest();

        SliderItem? slider = await _sliderService.GetSliderItemById((int)id);
        if (slider == null) return NotFound();

        string path = Path.Combine(_env.WebRootPath, "imgs", "sliders", slider.ImageUrl);
        System.IO.File.Delete(path);

        await _sliderService.Delete(slider.Id);
        return RedirectToAction(nameof(Index));
    }
}

using Slider.DAL.Models;

namespace Slider.MVC.ViewModels.Commons;

public class HomeVM
{
    public ICollection<SliderItem> Sliders { get; set; }
}

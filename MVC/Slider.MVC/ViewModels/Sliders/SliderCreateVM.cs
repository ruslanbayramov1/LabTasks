using System.ComponentModel.DataAnnotations;

namespace Slider.MVC.ViewModels.Sliders;

public class SliderCreateVM
{
    [Required]
    [MaxLength(64, ErrorMessage = "Title have to be less than 64 characters")]
    public string Title { get; set; }

    [Required]
    [MaxLength(255, ErrorMessage = "Description have to be less than 255 characters")]
    public string ShortDesc { get; set; }

    [Required]
    public IFormFile File { get; set; }
}

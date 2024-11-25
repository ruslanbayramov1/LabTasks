using System.ComponentModel.DataAnnotations;

namespace Slider.MVC.ViewModels.Sliders;

public class SliderUpdateVM
{
    [Required]
    [MaxLength(64, ErrorMessage = "Title have to be less than 64 characters")]
    public string Title { get; set; }

    [Required]
    [MaxLength(255, ErrorMessage = "Description have to be less than 255 characters")]
    public string ShortDesc { get; set; }

    public IFormFile? File { get; set; }

    [Required]
    [Range(0, 100, ErrorMessage = "Offer have to be positive value, between 0 and 100")]
    public int Offer { get; set; }
}

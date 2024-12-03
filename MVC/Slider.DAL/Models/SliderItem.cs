using System.ComponentModel.DataAnnotations;

namespace Slider.DAL.Models;

public class SliderItem : BaseEntity
{
    [MaxLength(64)]
    public string Title { get; set; } = null!;

    [MaxLength(255)]
    public string ShortDesc { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;
}

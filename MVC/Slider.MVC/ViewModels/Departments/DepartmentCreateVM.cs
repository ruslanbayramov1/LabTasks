using System.ComponentModel.DataAnnotations;

namespace Slider.MVC.ViewModels.Departments;

public class DepartmentCreateVM
{
    [Required, MaxLength(32)]
    public string Name { get; set; }
}

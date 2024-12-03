namespace Slider.DAL.Models;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Service> Services { get; set; }
}

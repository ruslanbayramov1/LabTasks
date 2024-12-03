namespace Slider.DAL.Models;

public class Service : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}

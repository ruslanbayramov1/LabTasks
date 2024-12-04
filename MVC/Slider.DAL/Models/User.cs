using Microsoft.AspNetCore.Identity;

namespace Slider.DAL.Models;

public class User : IdentityUser
{
    public string FullName { get; set; }
}

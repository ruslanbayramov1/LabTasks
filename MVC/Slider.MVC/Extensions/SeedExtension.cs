using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Slider.DAL.Contexts;
using Slider.DAL.Enums;
using Slider.DAL.Models;

namespace Slider.MVC.Extensions;

public static class SeedExtension
{
    public static void UseCustomUserData(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            CreateRoles(_roleManager).Wait();
            CreateAdmin(_userManager).Wait();
        }
    }

    private static async Task CreateRoles(RoleManager<IdentityRole> _roleManager)
    {
        int count = await _roleManager.Roles.CountAsync();
        if (count == 0)
        {
            foreach (Roles role in Enum.GetValues(typeof(Roles)))
            {
                await _roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }
        }
    }

    private static async Task CreateAdmin(UserManager<User> _userManager)
    {
        User? user = await _userManager.Users.Where(x => x.NormalizedUserName == "ADMIN").FirstOrDefaultAsync();

        if (user == null)
        {
            user = new User
            { 
                UserName = "admin",
                FullName = "admin",
                Email = "admin@gmail.com"
            };
            await _userManager.CreateAsync(user, "123");
            await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());
        }
    }



    private static async Task UpdateDBAsync(SliderDbContext _context)
    {
       await _context.Database.MigrateAsync();

    }
}

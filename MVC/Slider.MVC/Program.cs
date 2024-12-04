using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Slider.BS.Services.Abstractions;
using Slider.BS.Services.Implements;
using Slider.DAL.Contexts;
using Slider.DAL.Models;
using Slider.MVC.Extensions;

namespace Slider.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string? connStr = builder.Configuration.GetConnectionString("MSSql");
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<SliderDbContext>(opt =>
        {
            opt.UseSqlServer(connStr);
        });

        builder.Services.AddScoped<ISliderService, SliderService>();
        builder.Services.AddScoped<IServiceService, ServiceService>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();

        builder.Services.AddIdentity<User, IdentityRole>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
            opt.Password.RequiredUniqueChars = 3;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 3;
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Lockout.AllowedForNewUsers = true;
            opt.Lockout.MaxFailedAccessAttempts = 3;
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
        })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<SliderDbContext>();

        builder.Services.ConfigureApplicationCookie(x => {
            x.LoginPath = "/Account/Login";
            x.AccessDeniedPath = "/Home/Denied";
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseAuthorization();
        app.UseCustomUserData();
        app.UseStaticFiles();

        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

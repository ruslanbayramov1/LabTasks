using Microsoft.EntityFrameworkCore;
using Slider.BS.Services.Abstractions;
using Slider.BS.Services.Implements;
using Slider.DAL.Contexts;

namespace Slider.MVC
{
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Ntier.BSL.Services.Abstractions;
using Ntier.BSL.Services.Implements;
using Ntier.DAL.Contexts;

namespace Ntier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string? connStr = builder.Configuration.GetConnectionString("MSSql");
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<NtierDbContext>(opt => {
                opt.UseSqlServer(connStr);
            });
            builder.Services.AddScoped<IUserService, UserService>();

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
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

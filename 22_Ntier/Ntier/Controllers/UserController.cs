using Microsoft.AspNetCore.Mvc;
using Ntier.BSL.Services.Abstractions;
using Ntier.DAL.Contexts;
using Ntier.DAL.Models;
using Ntier.ViewModels.Commons;
using Ntier.ViewModels.Users;

namespace Ntier.Controllers;

public class UserController : Controller
{
    #region notes
    // Constructor that accepts context via DI in program.cs AddScoped
    #endregion
    private readonly NtierDbContext _context;
    private readonly IUserService _userService;
    public UserController(NtierDbContext context, IUserService userService) // we can both use context directly itself and also service
    {
        _context = context; 
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        List<User> users = await _userService.GetAll(); // calling with service

        UserVM vm = new();
        vm.Profiles = _context.Users.Select(x => new UserProfileItemVM // calling with context itself and show only specified data here, short query will execute
        { 
            Name = x.Name,
            Email = x.Email,
        }).ToList();

        return View(vm);
    }
}

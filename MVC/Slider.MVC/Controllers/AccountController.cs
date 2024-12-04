using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Slider.DAL.Enums;
using Slider.DAL.Models;
using Slider.MVC.ViewModels.Auths;

namespace Slider.MVC.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    { 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM vm, string? returnUrl)
    {
        if (User.Identity?.IsAuthenticated ?? false) return RedirectToAction("Index", "Home");

        if (!ModelState.IsValid)
        { 
            return View();
        }

        User? user = await _userManager.FindByNameAsync(vm.UserName);
        if (user == null)
        {
            ModelState.AddModelError("", "The username or password is wrong");
            return View();
        }
        
        var res = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, true);

        if (!res.Succeeded)
        {
            if (res.IsLockedOut)
            {
                ModelState.AddModelError("", $"Wait until {user.LockoutEnd.ToString()}");
            }
            else if (res.IsNotAllowed)
            {
                ModelState.AddModelError("", $"The username or password is wrong");
            }
            else
            {
                ModelState.AddModelError("", $"The username or password is wrong");
            }
            return View();
        }

        if (!returnUrl.IsNullOrEmpty())
        { 
            return Redirect(returnUrl);
        }

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        return View();
    }
}

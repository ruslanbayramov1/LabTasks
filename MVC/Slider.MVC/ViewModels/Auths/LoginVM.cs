﻿using System.ComponentModel.DataAnnotations;

namespace Slider.MVC.ViewModels.Auths;

public class LoginVM
{
    [Required, MaxLength(32)]
    public string UserName { get; set; }
    [Required, MaxLength(24)]
    public string Password { get; set; }
    public bool RememberMe { get; set; } = default;
}

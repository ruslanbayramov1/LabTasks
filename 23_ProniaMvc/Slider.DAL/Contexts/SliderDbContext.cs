﻿using Microsoft.EntityFrameworkCore;
using Slider.DAL.Models;

namespace Slider.DAL.Contexts;

public class SliderDbContext : DbContext
{
    public DbSet<SliderItem> Sliders { get; set; }

    public SliderDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
}

﻿namespace Slider.DAL.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;
}

﻿using Microsoft.EntityFrameworkCore;
using Slider.BS.Services.Abstractions;
using Slider.DAL.Contexts;
using Slider.DAL.Models;

namespace Slider.BS.Services.Implements;

public class SliderService : ISliderService
{
    private readonly SliderDbContext _context;
    public SliderService(SliderDbContext context)
    {
        _context = context;
    }
    public async Task Create(SliderItem slider)
    {
        await _context.AddAsync(slider);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        SliderItem? slider = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);

        if (slider == null) return;
        _context.Sliders.Remove(slider);
        await _context.SaveChangesAsync();
    }

    public async Task<SliderItem> GetSliderItemById(int id)
    {
        SliderItem? slider = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);
        return slider;
    }

    public async Task<List<SliderItem>> GetAllSliderItems()
    {
        return await _context.Sliders.Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task Update(int id, SliderItem newSlider)
    {
        SliderItem? slider = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);

        if (slider == null) return;

        slider.Title = newSlider.Title;
        slider.ShortDesc = newSlider.ShortDesc;
        slider.Offer = newSlider.Offer;
        slider.ImageUrl = newSlider.ImageUrl;
        await _context.SaveChangesAsync();
    }
}

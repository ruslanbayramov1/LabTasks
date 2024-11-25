using Slider.DAL.Models;

namespace Slider.BS.Services.Abstractions;

public interface ISliderService
{
    Task<List<SliderItem>> GetAllSliderItems();
    Task<SliderItem> GetSliderItemById(int id);
    Task Create(SliderItem slider);
    Task Update(int id, SliderItem slider);
    Task Delete(int id);
}

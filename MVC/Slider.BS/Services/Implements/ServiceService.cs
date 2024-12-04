using Microsoft.EntityFrameworkCore;
using Slider.BS.Services.Abstractions;
using Slider.DAL.Contexts;
using Slider.DAL.Models;

namespace Slider.BS.Services.Implements;

public class ServiceService : IServiceService
{
    private readonly SliderDbContext _context;
    public ServiceService(SliderDbContext context)
    {
        _context = context;
    }
    public async Task<int> CreateService(Service service)
    {
        await _context.Services.AddAsync(service);
        int res = await _context.SaveChangesAsync();
        return res;
    }

    public async Task<int> DeleteService(int id)
    {
        Service service = await GetServiceById(id);
        service.IsDeleted = true;
        int res = await _context.SaveChangesAsync();
        return res;
    }

    public async Task<List<Service>> GetAllServices()
    {
        List<Service> services = await _context.Services.Where(x => !x.IsDeleted).ToListAsync();
        return services;
    }

    public async Task<Service> GetServiceById(int id)
    {
        Service? service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
        if (service == null)
        {
            throw new Exception("The id is false");
        }

        return service;
    }

    public async Task<int> UpdateService(int id, Service newService)
    {
        Service oldService = await GetServiceById(id);
        oldService.Title = newService.Title;
        oldService.Description = newService.Description;
        oldService.Icon = newService.Icon;
        oldService.DepartmentId = newService.DepartmentId;
        int res = await _context.SaveChangesAsync();

        return res;
    }
}

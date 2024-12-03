using Slider.DAL.Models;

namespace Slider.BS.Services.Abstractions;

public interface IServiceService
{
    Task<List<Service>> GetAllServices();
    Task<Service> GetServiceById(int id);
    Task<int> CreateService(Service service);
    Task<int> DeleteService(int id);
    Task<int> UpdateService(int id, Service service);
}

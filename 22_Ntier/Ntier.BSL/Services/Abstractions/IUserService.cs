using Ntier.DAL.Models;

namespace Ntier.BSL.Services.Abstractions;

public interface IUserService
{
    Task<List<User>> GetAll();
}

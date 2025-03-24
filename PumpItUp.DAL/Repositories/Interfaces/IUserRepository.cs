using PumpItUp.DAL.Models;

namespace PumpItUp.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(long userId);
    }
}
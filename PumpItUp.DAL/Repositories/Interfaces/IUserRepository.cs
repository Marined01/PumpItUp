using PumpItUp.DAL.Models;

namespace PumpItUp.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(long userId);

        // Task<IEnumerable<User>> GetAllAsync();

        // Task AddAsync(User user);

        // Task UpdateAsync(User user);

        // Task<User?> GetByEmailAsync(string email);

        // Task DeleteAsync(long id);
    }
}
using PumpItUp.DAL.Models;

namespace PumpItUp.DAL.Repositories.Interfaces;

public interface IRoleRepository
{
    Task<Role> GetByIdAsync(long roleId);
    // Task<IEnumerable<Role>> GetAllAsync();
    // Task AddAsync(Role role);
    // Task UpdateAsync(Role role);
    // Task DeleteAsync(long roleId);
}
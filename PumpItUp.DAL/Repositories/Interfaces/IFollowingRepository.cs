using PumpItUp.DAL.Models;

namespace PumpItUp.DAL.Repositories.Interfaces
{
    public interface IFollowingRepository
    {
        Task<IEnumerable<Following>> GetAllFollowingsAsync();
        Task<Following?> GetFollowingByIdAsync(long id);
        Task AddFollowingAsync(Following following);
        Task DeleteFollowingAsync(long id);
        Task<bool> IsFollowingExistsAsync(long userOneId, long userBeingFollowedId);
    }
}
using Microsoft.EntityFrameworkCore;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Interfaces;

namespace PumpItUp.DAL.Repositories;

public class FollowingRepository : IFollowingRepository
{
    private readonly AppDbContext _context;

    public FollowingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Following>> GetAllFollowingsAsync()
    {
        return await _context.Followings.ToListAsync();
    }

    public async Task<Following?> GetFollowingByIdAsync(long id)
    {
        return await _context.Followings.FindAsync(id);
    }

    public async Task AddFollowingAsync(Following following)
    {
        _context.Followings.Add(following);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFollowingAsync(long id)
    {
        var following = await _context.Followings.FindAsync(id);
        if (following != null)
        {
            _context.Followings.Remove(following);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> IsFollowingExistsAsync(long userOneId, long userBeingFollowedId)
    {
        return await _context.Followings
            .AnyAsync(f => f.FollowerId == userOneId && f.FollowingId == userBeingFollowedId);
    }
}
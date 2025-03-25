using Microsoft.EntityFrameworkCore;
using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Services;

public class FollowingService
{
    private readonly AppDbContext _context;
    private readonly FollowingMapper _mapper;
    public FollowingService(AppDbContext context)
    {
        _context = context;
        _mapper = new FollowingMapper();
    }

    public async Task<bool> ExistingSubscriptions(long followerId, long followingId)
    {
        var following = await _context.Followings
            .FirstOrDefaultAsync(f => f.follower == followerId && f.following == followingId);
        return true;
    }

    public async Task<Following> CreateFollowingAsync(FollowingRequest followingRequest)
    {
        var following = _mapper.MapToSubscription(followingRequest);
        _context.Followings.Add(following);
        await _context.SaveChangesAsync();
        return following;
    }

    public async Task<IEnumerable<Following>> GetAllFollowingsAsync()
    {
        return await _context.Followings.ToListAsync();
    }

    public async Task<Following?> GetFollowingByIdAsync(long id)
    {
        return await _context.Followings.FindAsync(id);
    }
}
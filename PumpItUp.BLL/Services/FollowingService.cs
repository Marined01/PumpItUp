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
        .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);

        return following != null;
    }

    public async Task<Following> CreateFollowingAsync(FollowingRequest followingRequest)
    {
        Console.WriteLine($"Received Request: FollowerId = {followingRequest.FollowerId}, FollowingId = {followingRequest.FollowingId}");
        // if (followingRequest.FollowerId == 0 || followingRequest.FollowingId == 0)
        // {
        //     throw new Exception("FollowerId or FollowingId cannot be 0");
        // }

        var following = _mapper.MapToSubscription(followingRequest);
        _context.Followings.Add(following);
        await _context.SaveChangesAsync();
        
        return following;
    }

    public async Task<IEnumerable<Following>> GetAllFollowingsAsync()
    {
        return await _context.Followings
            .OrderByDescending(f => f.CreatedAt) // Сортування за датою створення 
            .ToListAsync();
    }

    public async Task<IEnumerable<Following>> GetFollowingByIdAsync(long id)
    {
        var followings = await _context.Followings
            .Where(f => f.FollowerId == id || f.FollowingId == id)
            .ToListAsync();

        if (!followings.Any())
        {
            throw new Exception("Користувача не знайдено");
        }

        return followings;
    }

}
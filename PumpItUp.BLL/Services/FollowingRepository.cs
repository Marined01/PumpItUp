using Microsoft.EntityFrameworkCore;
using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;

namespace PumpItUp.BLL.Services;

public class FollowingService
{
    private readonly AppDbContext _context;
    private readonly FollowingMapper _mapper;
    public FollowingService(AppDbContext context, FollowingMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> ExistingSubscriptions(long followerId, long followingId)
    {
        var following = await _context.Followings
            .FirstOrDefaultAsync(f => f.follower == followerId && f.following == followingId);
        return true;
    }
}
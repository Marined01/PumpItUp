using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace PumpItUp.BLL.Services
{
    public class FollowingService
    {
        private readonly AppDbContext _context;
        private readonly FollowingMapper _mapper;
        public FollowingService(AppDbContext context, FollowingMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> existingSubscriptions(long followerId, long followingId)
        {
            
            return true;
        }

        

    }
}

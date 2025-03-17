using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly UserMapper _userMapper;

        public UserService(AppDbContext context)
        {
            _context = context;
            _userMapper = new UserMapper();
        }

        public async Task<User> CreateUserAsync(UserRequest userRequest)
        {
            User user = _userMapper.MapToUser(userRequest);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
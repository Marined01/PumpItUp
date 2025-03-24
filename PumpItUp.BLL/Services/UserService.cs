using Microsoft.EntityFrameworkCore;
using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Implementations;

namespace PumpItUp.BLL.Services;

public class UserService
{
    private readonly AppDbContext _context;
    private readonly UserMapper _userMapper;
    private readonly UserRepository _userRepository;
    
    public UserService(AppDbContext context)
    {
        _context = context;
        _userMapper = new UserMapper();
        _userRepository = new UserRepository(context);
    }
    
    

    public async Task<User> CreateUserAsync(UserRequest userRequest)
    {
        var user = _userMapper.MapToUser(userRequest);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetUserByIdAsync(long userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }
}
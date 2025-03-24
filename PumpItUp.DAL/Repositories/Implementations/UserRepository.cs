using Microsoft.EntityFrameworkCore;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.Exceptions;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Interfaces;

namespace PumpItUp.DAL.Repositories.Implementations;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User> GetByIdAsync(long userId)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            throw new UserNotFoundException($"User with ID=[{userId}] not found.", userId);
        }

        return user;
    }
}
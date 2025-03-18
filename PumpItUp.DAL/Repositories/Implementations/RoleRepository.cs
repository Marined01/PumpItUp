using Microsoft.EntityFrameworkCore;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.Exceptions;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Interfaces;

namespace PumpItUp.DAL.Repositories.Implementations;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Role> GetByIdAsync(long roleId)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(r => r.Id == roleId);

        if (role == null)
        {
            throw new RoleNotFoundException($"Role with ID=[{roleId}] not found.", roleId);
        }

        return role;
    }
}
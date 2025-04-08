using Microsoft.EntityFrameworkCore;
using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Exceptions;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Implementations;

namespace PumpItUp.BLL.Services;

public class RoleService
{
    private readonly AppDbContext _context;
    private readonly RoleMapper _roleMapper;
    private readonly RoleRepository _roleRepository;

    public RoleService(AppDbContext context)
    {
        _context = context;
        _roleMapper = new RoleMapper();
        _roleRepository = new RoleRepository(context);
    }

    public async Task<Role> CreateRoleAsync(RoleRequest roleRequest)
    {
        Role role = _roleMapper.MapToRole(roleRequest);
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();

        return role;
    }

    public async Task<Role> GetRoleByIdAsync(long roleId)
    {
        return await _roleRepository.GetByIdAsync(roleId);
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task DeleteRoleAsync(long roleId)
    {
        var role = await _roleRepository.GetByIdAsync(roleId);
        if (role == null)
        {
            throw new RoleNotFoundException($"Role with ID={roleId} not found", roleId);
        }

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }
}
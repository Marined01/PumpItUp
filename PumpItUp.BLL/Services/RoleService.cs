using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Services
{
    public class RoleService
    {
        private readonly AppDbContext _context;
        private readonly RoleMapper _roleMapper;

        public RoleService(AppDbContext context)
        {
            _context = context;
            _roleMapper = new RoleMapper();
        }

        public async Task<Role> CreateRoleAsync(RoleRequest roleRequest)
        {
            Role role = _roleMapper.MapToRole(roleRequest);
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return role;
        }
    }
}
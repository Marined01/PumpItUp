using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Mappers
{
    public class RoleMapper
    {
        public Role MapToRole(RoleRequest roleRequest)
        {
            return new Role
            {
                Name = roleRequest.Name,
                CreatedAt = roleRequest.CreatedAt,
                UpdatedAt = roleRequest.UpdatedAt,
                UserId = roleRequest.UserId
            };
        }
    }
}
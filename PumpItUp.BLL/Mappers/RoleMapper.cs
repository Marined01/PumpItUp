using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Mappers;

public class RoleMapper
{
    public Role MapToRole(RoleRequest roleRequest)
    {
        return new Role
        {
            Name = roleRequest.Name,
            UserId = roleRequest.UserId
        };
    }
}
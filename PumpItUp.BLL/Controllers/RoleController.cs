using Microsoft.AspNetCore.Mvc;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.DTOs;

namespace PumpItUp.BLL.Controllers;

public class RoleController : Controller
{
    private readonly RoleService _roleService;

    public RoleController(RoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public IActionResult CreateRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromForm] RoleRequest roleRequest)
    {
        await _roleService.CreateRoleAsync(roleRequest);
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetRoleById(long roleId)
    {
        var role = await _roleService.GetRoleByIdAsync(roleId);
        if (role == null)
        {
            return NotFound();
        }

        return View("RoleDetails", role);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return View(roles);
    }
}
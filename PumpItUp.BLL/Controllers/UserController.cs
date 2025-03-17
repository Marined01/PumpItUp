using Microsoft.AspNetCore.Mvc;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.DTOs;

namespace PumpItUp.BLL.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserRequest userRequest)
    {
        await _userService.CreateUserAsync(userRequest);

        return View();
    }
}
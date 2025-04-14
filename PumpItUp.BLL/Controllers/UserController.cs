using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;

namespace PumpItUp.BLL.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;
    private readonly AppDbContext _dbContext;
    private readonly AuthService _authService;

    public UserController(UserService userService, AppDbContext dbContext, AuthService authService)
    {
        _userService = userService;
        _dbContext = dbContext;
        _authService = authService;
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromForm] UserRequest userRequest)
    {
        await _userService.CreateUserAsync(userRequest);

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        return View("UserDetails", user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteUserList()
    {
        var users = await _userService.GetAllUsers();
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        await _userService.DeleteUserAsync(userId);
        return RedirectToAction("UserDeleted");
    }

    [HttpGet]
    public IActionResult UserDeleted()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        
        if (userId == null)
        {
            return RedirectToAction("Login", "Auth");
        }
        
        var user = await _userService.GetUserByIdAsync(userId.Value);
        
        if (user == null)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
        
        return View(user);
    }
}
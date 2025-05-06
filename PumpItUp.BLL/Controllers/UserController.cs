using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace PumpItUp.BLL.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;
    private readonly AppDbContext _dbContext;
    private readonly AuthService _authService;
    private readonly string _profileImagesFolder;

    public UserController(UserService userService, AppDbContext dbContext, AuthService authService, IWebHostEnvironment hostEnvironment)
    {
        _userService = userService;
        _dbContext = dbContext;
        _authService = authService;
        _profileImagesFolder = Path.Combine("D:\\university\\6 semester\\software engineering\\WebProject\\PumpItUp.DAL\\storage\\images\\profiles");

        if (!Directory.Exists(_profileImagesFolder))
        {
            Directory.CreateDirectory(_profileImagesFolder);
        }
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

    [HttpPost]
    public async Task<IActionResult> UploadAvatar(IFormFile file)
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        
        if (userId == null)
        {
            return RedirectToAction("Login", "Auth");
        }
        
        if (file != null && file.Length > 0)
        {
            var user = await _userService.GetUserByIdAsync(userId.Value);
            
            if (user == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(user.AvatarUrl))
            {
                var oldFileName = Path.GetFileName(user.AvatarUrl);
                var oldFilePath = Path.Combine(_profileImagesFolder, oldFileName);
                if (System.IO.File.Exists(oldFilePath))
                {
                    try
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Error deleting old avatar: {ex.Message}");
                    }
                }
            }
            
            var fileName = $"{userId}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(_profileImagesFolder, fileName);
            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            var fileUrl = $"/images/profiles/{fileName}";
            user.AvatarUrl = fileUrl;
            
            await _dbContext.SaveChangesAsync();
            
            return RedirectToAction("Profile");
        }

        TempData["Error"] = "Please select a valid image file.";
        return RedirectToAction("Profile");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(User updatedUser)
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null) return RedirectToAction("Login", "Auth");

        var user = await _dbContext.Users.FindAsync((long?)userId);

        if (user == null) return NotFound();

        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.Email = updatedUser.Email;
        user.Age = updatedUser.Age;
        user.Sex = updatedUser.Sex;
        user.FitnessLevel = updatedUser.FitnessLevel;

        await _dbContext.SaveChangesAsync();

        TempData["Success"] = "Профіль оновлено успішно!";
        
        return View("Profile", user);
    }
}
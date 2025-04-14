using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Exceptions;

namespace PumpItUp.BLL.Controllers;

public class AuthController : Controller
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public async Task<IActionResult> SignUp()
    {
        var model = new RegistrationRequest
        {
            SexOptions = await _authService.GetSexOptionsAsync(),
            FitnessLevelOptions = await _authService.GetFitnessLevelOptionsAsync()
        };
        return View("SignUpPage", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignUp(RegistrationRequest model)
    {
        try
        {
            await _authService.RegisterUserAsync(model);
            return RedirectToAction("Login", "Auth");
        }
        catch (EmailAlreadyExists)
        {
            ModelState.AddModelError("", "Такий емейл уже існує");
        }
        catch (PasswordsDoNotMatch)
        {
            ModelState.AddModelError("", "Паролі не співпадають");
        }

        model.SexOptions = await _authService.GetSexOptionsAsync();
        model.FitnessLevelOptions = await _authService.GetFitnessLevelOptionsAsync();
        return View("SignUpPage", model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View("LoginPage", new LoginRequest());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        if (!ModelState.IsValid) return View("LoginPage", model);

        var user = await _authService.LoginUserAsync(model);
        if (user != null)
        {
            HttpContext.Session.SetInt32("UserId", (int)user.Id!.Value);
            HttpContext.Session.SetString("UserName", $"{user.FirstName} {user.LastName}");
            
            return RedirectToAction("Profile", "User");
        }

        ModelState.AddModelError("", "Неправильний емейл або пароль.");
        return View("LoginPage", model);
    }
    
    [HttpGet]
    public IActionResult Logout()
    {
        // Clear the session
        HttpContext.Session.Clear();
        
        return RedirectToAction("Index", "Home");
    }
}
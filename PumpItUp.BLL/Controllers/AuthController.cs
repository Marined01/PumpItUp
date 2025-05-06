using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PumpItUp.BLL.Models.ViewModels;
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
    
    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View(new PasswordResetRequest());
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(PasswordResetRequest model)
    {
        if (!ModelState.IsValid)
            return View(model);
            
        try
        {
            await _authService.GeneratePasswordResetTokenAsync(model.Email);
            
            // Log the success for debugging purposes
            Console.WriteLine($"Password reset email sent to {model.Email}");
            
            return RedirectToAction("ForgotPasswordConfirmation");
        }
        catch (Exception ex)
        {
            // Log the exception but don't reveal it to the user for security reasons
            Console.WriteLine($"Error sending password reset email: {ex.Message}");
            
            // Even if email doesn't exist or sending fails, still show success message for security reasons
            return RedirectToAction("ForgotPasswordConfirmation");
        }
    }
    
    [HttpGet]
    public IActionResult ForgotPasswordConfirmation()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult ResetPassword(string token, string email)
    {
        var model = new ResetPasswordViewModel
        {
            Token = token,
            Email = email
        };
        return View(model);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
            
        try
        {
            await _authService.ResetPasswordAsync(model.Email, model.Token, model.Password);
            return RedirectToAction("ResetPasswordConfirmation");
        }
        catch (Exception)
        {
            ModelState.AddModelError("", "Невірний токен або закінчився термін його дії");
            return View();
        }
    }
    
    [HttpGet]
    public IActionResult ResetPasswordConfirmation()
    {
        return View();
    }
}
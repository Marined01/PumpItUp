using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PumpItUp.DAL.Common;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Exceptions;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly EmailService _emailService;

    public AuthService(AppDbContext context, EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task<IEnumerable<SelectionItem>> GetSexOptionsAsync()
    {
        return Enum.GetValues(typeof(Sex))
            .Cast<Sex>()
            .Select(sex => new SelectionItem
            {
                Id = (int)sex,
                Name = sex.ToString()
            })
            .ToList();
    }

    public async Task<IEnumerable<SelectionItem>> GetFitnessLevelOptionsAsync()
    {
        return Enum.GetValues(typeof(FitnessLevel))
            .Cast<FitnessLevel>()
            .Select(level => new SelectionItem
            {
                Id = (int)level,
                Name = level.ToString()
            })
            .ToList();
    }

    public async Task RegisterUserAsync(RegistrationRequest model)
    {
        if (model.Password != model.ConfirmPassword)
            throw new PasswordsDoNotMatch("Passwords do not match.");

        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Email.ToLower() == model.Email.ToLower());
        if (existingUser != null)
            throw new EmailAlreadyExists("Email already exists.");

        var names = model.FullName?.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
        var firstName = names.Length > 0 ? names[0] : "";
        var lastName = names.Length > 1 ? names[1] : "";

        var newUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = model.Email,
            Password = HashPassword(model.Password),
            Sex = model.Sex,
            Age = model.Age,
            FitnessLevel = model.FitnessLevel,
            CreatedAt = DateTime.UtcNow,
            RoleId = 1,
            FollowingId = 1,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> LoginUserAsync(LoginRequest model)
    {
        var hashedPassword = HashPassword(model.Password);
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == hashedPassword);
            
        if (user != null && user.RoleId == 0)
        {
            user.RoleId = 1;
        }
        
        if (user != null && user.FollowingId == 0)
        {
            user.FollowingId = 1;
        }
        
        return user;
    }
    
    public async Task GeneratePasswordResetTokenAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        
        if (user == null)
            return;
        
        var token = GenerateRandomToken();
        
        var tokenExpiry = DateTime.UtcNow.AddHours(24);
        
        user.ResetPasswordToken = token;
        user.ResetPasswordTokenExpiry = tokenExpiry;
        
        await _context.SaveChangesAsync();
        
        await _emailService.SendPasswordResetEmailAsync(email, token);
    }
    
    public async Task ResetPasswordAsync(string email, string token, string newPassword)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => 
            u.Email.ToLower() == email.ToLower() && 
            u.ResetPasswordToken == token &&
            u.ResetPasswordTokenExpiry > DateTime.UtcNow);
        
        if (user == null)
            throw new InvalidOperationException("Invalid or expired token");
        
        user.Password = HashPassword(newPassword);
        
        user.ResetPasswordToken = null;
        user.ResetPasswordTokenExpiry = null;
        
        await _context.SaveChangesAsync();
    }

    private string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
    
    private string GenerateRandomToken()
    {
        var tokenBytes = RandomNumberGenerator.GetBytes(32);
        return Convert.ToBase64String(tokenBytes);
    }
}
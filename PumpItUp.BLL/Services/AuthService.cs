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

    public AuthService(AppDbContext context)
    {
        _context = context;
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
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> LoginUserAsync(LoginRequest model)
    {
        var hashedPassword = HashPassword(model.Password);
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == hashedPassword);
    }

    private string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}
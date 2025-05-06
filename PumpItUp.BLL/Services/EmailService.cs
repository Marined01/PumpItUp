using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace PumpItUp.BLL.Services;

public class EmailService
{
    private readonly IConfiguration _configuration;
    
    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_configuration["EmailSettings:FromEmail"], _configuration["EmailSettings:FromName"]),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };
        
        mailMessage.To.Add(email);
        
        using var smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpServer"], 
            int.Parse(_configuration["EmailSettings:SmtpPort"]))
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(
                _configuration["EmailSettings:Username"], 
                _configuration["EmailSettings:Password"])
        };
        
        await smtpClient.SendMailAsync(mailMessage);
    }
    
    public async Task SendPasswordResetEmailAsync(string email, string token)
    {
        var resetUrl = $"{_configuration["ApplicationUrl"]}/Auth/ResetPassword?token={WebUtility.UrlEncode(token)}&email={WebUtility.UrlEncode(email)}";
        
        var message = $@"
        <html>
        <body>
            <h2>Reset Your Password</h2>
            <p>Please click the link below to reset your password:</p>
            <p><a href='{resetUrl}'>Reset Password</a></p>
            <p>If you did not request a password reset, please ignore this email.</p>
            <p>This link will expire in 24 hours.</p>
        </body>
        </html>";
        
        await SendEmailAsync(email, "Password Reset Request", message);
    }
}
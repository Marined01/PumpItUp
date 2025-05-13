using System.ComponentModel.DataAnnotations;

namespace PumpItUp.DAL.DTOs
{
    public class PasswordResetRequest
    {
        [Required(ErrorMessage = "Електронна адреса обов'язкова")]
        [EmailAddress(ErrorMessage = "Невірний формат електронної адреси")]
        public string Email { get; set; } = string.Empty;
    }
}
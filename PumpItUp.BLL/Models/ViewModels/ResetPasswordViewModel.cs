using System.ComponentModel.DataAnnotations;

namespace PumpItUp.BLL.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Поле електронної адреси обов'язкове")]
        [EmailAddress(ErrorMessage = "Невалідний формат електронної адреси")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "Поле паролю обов'язкове")]
        [StringLength(100, ErrorMessage = "Пароль має містити щонайменше {2} символів", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        [Required(ErrorMessage = "Поле підтвердження паролю обов'язкове")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string? ConfirmPassword { get; set; }
        
        public string? Token { get; set; }
    }
}
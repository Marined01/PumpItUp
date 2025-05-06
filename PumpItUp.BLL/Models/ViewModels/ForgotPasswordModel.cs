using System.ComponentModel.DataAnnotations;

namespace PumpItUp.BLL.Models.ViewModels;

public class ForgotPasswordModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }
    public bool EmailSent { get; set; }
}

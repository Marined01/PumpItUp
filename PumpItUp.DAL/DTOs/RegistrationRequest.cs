using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PumpItUp.DAL.Common;

namespace PumpItUp.DAL.DTOs;

public class RegistrationRequest
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public Sex Sex { get; set; }
    public int Age { get; set; }
    public FitnessLevel FitnessLevel { get; set; }
    [ValidateNever]
    public IEnumerable<SelectionItem> SexOptions { get; set; } = Enumerable.Empty<SelectionItem>();
    [ValidateNever]
    public IEnumerable<SelectionItem> FitnessLevelOptions { get; set; } = Enumerable.Empty<SelectionItem>();
}

public class SelectionItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
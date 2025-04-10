using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PumpItUp.DAL.Common;

namespace PumpItUp.DAL.DTOs;

public class RegistrationRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public Sex Sex { get; set; }
    public int Age { get; set; }
    public FitnessLevel FitnessLevel { get; set; }
    [ValidateNever]
    public IEnumerable<SelectionItem> SexOptions { get; set; }
    [ValidateNever]
    public IEnumerable<SelectionItem> FitnessLevelOptions { get; set; }
}

public class SelectionItem
{
    public int Id { get; set; }
    public string Name { get; set; }
}
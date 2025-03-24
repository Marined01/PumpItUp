using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PumpItUp.BLL.Models;
using PumpItUp.DAL.Common;

namespace PumpItUp.DAL.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Required]
        [RegularExpression(AppConstants.FirstAndLastNamePattern,
            ErrorMessage = "First name must start with an capital letter and contains no digits or special characters")]
        public string? FirstName { get; set; }

        [Required]
        [RegularExpression(AppConstants.FirstAndLastNamePattern,
            ErrorMessage = "First name must start with an capital letter and contains no digits or special characters")]
        public string? LastName { get; set; }

        [Required]
        [RegularExpression(AppConstants.EmailPattern,
            ErrorMessage = "Email must be a valid email address format")]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(AppConstants.PasswordPattern,
            ErrorMessage = "Must be minimum 8 symbols long, using digits and latin letters, containing at least one" +
                           " digit, one uppercase letter, and one lowercase letter")]
        public string? Password { get; set; }

        [Url]
        public string? AvatarUrl { get; set; }

        [Required]
        public FitnessLevel FitnessLevel { get; set; }

        [Required]
        [RegularExpression(AppConstants.AgePattern,
            ErrorMessage = "Age must be a positive number")]
        public int Age { get; set; }

        [Required]
        public Sex Sex { get; set; }

        public BankData? BankData { get; set; }

        [Required]
        public bool HasPremiumSubscription { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public long RoleId { get; set; }

        [Required]
        public long FollowingId { get; set; }
    }
}
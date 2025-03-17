using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PumpItUp.DAL.Common;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Models
{
    [Table("bank_data")]
    public class BankData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string? CardHolderName { get; set; }

        [Required]
        [RegularExpression(AppConstants.CardNumberPattern, ErrorMessage = "Card number must be exactly 16 digits")]
        public string? CardNumber { get; set; }

        [Required]
        [RegularExpression(AppConstants.CvvPattern, ErrorMessage = "CVV must be 3 or 4 digits")]
        public string? Cvv { get; set; }

        [Required]
        [RegularExpression(AppConstants.ExpirationDatePattern, 
            ErrorMessage = "Expiration date must be in MM/YY format")]
        public string? ExpirationDate { get; set; }

        [Required]
        public string? BankName { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
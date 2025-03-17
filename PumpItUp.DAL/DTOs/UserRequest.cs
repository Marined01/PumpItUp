using PumpItUp.BLL.Models;
using PumpItUp.DAL.Common;

namespace PumpItUp.DAL.DTOs
{
    public class UserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? AvatarUrl { get; set; }
        public FitnessLevel FitnessLevel { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public BankData? BankData { get; set; }
        public bool HasPremiumSubscription { get; set; }
        public Role Role { get; set; }
        public long FollowingId { get; set; }
    }
}
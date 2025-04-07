using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Mappers
{
    public class UserMapper
    {
        public User MapToUser(UserRequest userRequest)
        {
            return new User
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                Password = userRequest.Password,
                AvatarUrl = userRequest.AvatarUrl,
                FitnessLevel = userRequest.FitnessLevel,
                Age = userRequest.Age,
                Sex = userRequest.Sex,
                BankData = userRequest.BankData,
                HasPremiumSubscription = userRequest.HasPremiumSubscription,
                FollowingId = userRequest.FollowingId
            };
        }

        public void UpdateUser(User user, UserRequest userRequest)
        {
            user.FirstName = userRequest.FirstName;
            user.LastName = userRequest.LastName;
            user.Email = userRequest.Email;
            user.Password = userRequest.Password;
            user.AvatarUrl = userRequest.AvatarUrl;
            user.FitnessLevel = userRequest.FitnessLevel;
            user.Age = userRequest.Age;
            user.Sex = userRequest.Sex;
            user.BankData = userRequest.BankData;
            user.HasPremiumSubscription = userRequest.HasPremiumSubscription;
            user.RoleId = userRequest.RoleId;
            user.FollowingId = userRequest.FollowingId;
            user.UpdatedAt = DateTime.UtcNow;
        }    }
}
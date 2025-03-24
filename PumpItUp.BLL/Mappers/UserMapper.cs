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
    }
}
using PumpItUp.DAL.Models;
using PumpItUp.DAL.DTOs;

namespace PumpItUp.BLL.Mappers
{
    public class FollowingMapper
    {

        public Following MapToSubscription(Following subscriptionRequest)
        {
            return new Following
            {
                follower = subscriptionRequest.follower,
                following = subscriptionRequest.following,
                CreatedAt = subscriptionRequest.CreatedAt,
                UpdatedAt = subscriptionRequest.UpdatedAt
            };
        }
    }
}

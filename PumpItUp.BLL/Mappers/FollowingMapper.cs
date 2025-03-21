using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Mappers;

public class FollowingMapper
{
    public Following MapToSubscription(FollowingRequest subscriptionRequest)
    {
        return new Following
        {
            follower = subscriptionRequest.FollowerId,
            following = subscriptionRequest.FollowingId
        };
    }
}
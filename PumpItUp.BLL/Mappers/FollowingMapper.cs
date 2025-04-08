using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Mappers;

public class FollowingMapper
{
    public Following MapToSubscription(FollowingRequest subscriptionRequest)
    {
        return new Following
        {
            FollowerId = subscriptionRequest.FollowerId,
            FollowingId = subscriptionRequest.FollowingId
        };
    }
}
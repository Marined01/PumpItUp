using Microsoft.AspNetCore.Mvc;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.DTOs;
using System.Security.Claims;

namespace PumpItUp.BLL.Controllers
{
    public class FollowingController : Controller
    {
        private FollowingService _subscriptionService;

        public FollowingController(FollowingService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }


        [HttpPost("follow/{followingId}")]
        public async Task<IActionResult> FollowUser(int followingId)
        {
            var followerId = GetCurrentUserId();

            if (followerId == followingId)
            {
                return BadRequest("Не можна підписатися на себе.");
            }

            var success = await _subscriptionService.existingSubscriptions(followerId, followingId);

            if (!success)
            {
                return Conflict("Ви вже підписані на цього користувача.");
            }

            return Ok("Успішно підписано!");
        }


        [HttpGet("subscription/{id}")]
        public async Task<IActionResult> GetSubscription(long id)
        {
            return NoContent();
        }
        private int GetCurrentUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}

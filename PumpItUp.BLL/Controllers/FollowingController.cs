using Microsoft.AspNetCore.Mvc;
using PumpItUp.BLL.Services;
using System.Security.Claims;
using PumpItUp.DAL.DTOs;

namespace PumpItUp.BLL.Controllers;

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

        var success = await _subscriptionService.ExistingSubscriptions(followerId, followingId);

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

    [HttpGet]
    public IActionResult CreateFollowing()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFollowing([FromForm] FollowingRequest followingRequest)
    {
        await _subscriptionService.CreateFollowingAsync(followingRequest);
        return View();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllFollowings()
    {
        var followings = await _subscriptionService.GetAllFollowingsAsync();
        return Ok(followings);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetFollowingById(long id)
    {
        var following = await _subscriptionService.GetFollowingByIdAsync(id);
        if (following == null)
        {
            return NotFound($"Following з ID {id} не знайдено.");
        }

        return Ok(following);
    }
}
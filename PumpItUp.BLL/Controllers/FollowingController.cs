using Microsoft.AspNetCore.Mvc;
using PumpItUp.BLL.Services;
using System.Security.Claims;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using PumpItUp.DAL.DTOs;


namespace PumpItUp.BLL.Controllers;

public class FollowingController : Controller
{
    private FollowingService _subscriptionService;

    public FollowingController(FollowingService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    public IActionResult CreateFollowing() 
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFollowing([FromBody] FollowingRequest followingRequest)
    {
        Console.WriteLine($"Received: FollowerId = {followingRequest.FollowerId}, FollowingId = {followingRequest.FollowingId}");

        // if (followingRequest.FollowerId == 0 || followingRequest.FollowingId == 0)
        // {
        //     return BadRequest("Invalid request data");
        // }

        await _subscriptionService.CreateFollowingAsync(followingRequest);
        return Json(new { success = true });
    }

    [HttpGet]
    [HttpGet]
    public async Task<IActionResult> GetFollowingById(long id)
    {
        try
        {
            var followings = await _subscriptionService.GetFollowingByIdAsync(id);
            return View("GetFollowingById", followings);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetAllFollowings()
    {
        var followings = await _subscriptionService.GetAllFollowingsAsync();
        return View(followings);
    }

    [HttpGet]
    public async Task<IActionResult> ExistingSubscriptions(long followerId, long followingId)
    {
        var result = await _subscriptionService.ExistingSubscriptions(followerId, followingId);
        return Json(result); 
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFollowing([FromQuery] long followerId, [FromQuery] long followingId)
    {
        var deleted = await _subscriptionService.DeleteFollowing(followerId, followingId);
        if (!deleted)
            return NotFound(new {message = "Following not found"});
        return Ok(new{Message = "Following deleted"});
    }
        
}
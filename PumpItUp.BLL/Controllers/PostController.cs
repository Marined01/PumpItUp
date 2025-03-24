using Microsoft.AspNetCore.Mvc;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.DTOs;

namespace PumpItUp.BLL.Controllers;

public class PostController : Controller
{
    private readonly PostService _postService;
    private readonly ILogger<PostController> _logger;

    public PostController(PostService postService, ILogger<PostController> logger)
    {
        _postService = postService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult CreatePost()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(PostRequest postRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(postRequest);
        }

        await _postService.CreatePostAsync(postRequest);
        _logger.LogInformation("New post created successfully.");
        return View(postRequest);
    }
}
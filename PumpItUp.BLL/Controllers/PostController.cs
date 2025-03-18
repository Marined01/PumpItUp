using Microsoft.AspNetCore.Mvc;
using PumpItUP.BLL.Services;
using PumpItUP.DAL.DTOs;

namespace PumpItUP.BLL.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly ILogger<PostController> _logger;

    public PostController(IPostService postService, ILogger<PostController> logger)
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
        return RedirectToAction("Index", "Home");
    }
}
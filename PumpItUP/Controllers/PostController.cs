using Microsoft.AspNetCore.Mvc;
using PumpItUP.Models;
using PumpItUP.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PumpItUP.Controllers
{
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            long userId = 1; // для прикладу (підключиш ідентифікацію користувача)

            await _postService.CreatePostAsync(model, userId);

            _logger.LogInformation($"User {userId} created a post.");

            return RedirectToAction("Index", "Home");
        }
    }
}

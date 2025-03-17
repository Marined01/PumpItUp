using PumpItUP.Models;
using PumpItUP.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace PumpItUP.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ILogger<PostService> _logger;

        public PostService(IPostRepository postRepository, ILogger<PostService> logger)
        {
            _postRepository = postRepository;
            _logger = logger;
        }

        public async Task CreatePostAsync(CreatePostViewModel model, long userId)
        {
            try
            {
                var post = new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    Likes = 0,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PostedBy = userId,
                    AttachmentId = null
                };

                await _postRepository.AddPostAsync(post);
                _logger.LogInformation($"Post created successfully by user {userId}.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating post: {ex.Message}");
                throw;
            }
        }
    }
}

using PumpItUP.DAL.DTOs;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Interfaces;

namespace PumpItUP.BLL.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly ILogger<PostService> _logger;

    public PostService(IPostRepository postRepository, ILogger<PostService> logger)
    {
        _postRepository = postRepository;
        _logger = logger;
    }

    public async Task CreatePostAsync(PostRequest postRequest)
    {
        var post = new Post
        {
            Title = postRequest.Title,
            Content = postRequest.Content,
            PostedBy = postRequest.PostedBy ?? 0 ,
            AttachmentId = postRequest.AttachmentId 
        };

        await _postRepository.CreatePostAsync(post);
        _logger.LogInformation($"Post created: {post.Title}");
    }
}
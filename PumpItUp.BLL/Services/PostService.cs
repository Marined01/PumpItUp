using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Interfaces;

namespace PumpItUp.BLL.Services;

public class PostService
{
    private readonly ILogger<PostService> _logger;
    private readonly AppDbContext _context;
    private readonly PostMapper _postMapper;

    public PostService(ILogger<PostService> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _postMapper = new PostMapper();
    }

    public async Task<Post> CreatePostAsync(PostRequest postRequest)
    {
        var post = _postMapper.MapToPost(postRequest);

        _context.Posts.Add(post);
        _logger.LogInformation($"Post created: {post.Title}");
        await _context.SaveChangesAsync();
        return post;
    }
}
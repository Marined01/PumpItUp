using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Post> GetPostByIdAsync(int id)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _context.Posts.ToListAsync();
    }
    
    public async Task<bool> DeletePostAsync(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        if (post == null)
        {
            _logger.LogWarning($"Post with ID {id} not found.");
            return false; 
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"Post deleted: {post.Title}");
        return true; 
    }
}
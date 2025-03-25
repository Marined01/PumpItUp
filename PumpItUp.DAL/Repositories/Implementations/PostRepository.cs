using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Interfaces;

namespace PumpItUp.DAL.Repositories.Implementations;

public class PostRepository : IPostRepository
{
    private static readonly List<Post> _posts = new();

    public async Task CreatePostAsync(Post post)
    {
        post.Id = _posts.Count + 1;
        post.CreatedAt = DateTime.UtcNow;
        post.UpdatedAt = DateTime.UtcNow;
        _posts.Add(post);
        await Task.CompletedTask;
    }
    
    public async Task<Post> GetPostByIdAsync(int id)
    {
        var post = _posts.FirstOrDefault(p => p.Id == id);
        return await Task.FromResult(post);
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await Task.FromResult(_posts.AsEnumerable());
    }
}
using PumpItUP.Models;

namespace PumpItUP.DAL.Repositories;

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
}

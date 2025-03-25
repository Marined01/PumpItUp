using PumpItUp.DAL.Models;

namespace PumpItUp.DAL.Repositories.Interfaces;

public interface IPostRepository
{
    Task CreatePostAsync(Post post);
    Task<Post> GetPostByIdAsync(int id);  
    Task<IEnumerable<Post>> GetAllPostsAsync();  
}
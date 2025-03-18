using PumpItUp.DAL.Models;

namespace PumpItUp.DAL.Repositories.Interfaces;

public interface IPostRepository
{
    Task CreatePostAsync(Post post);
}
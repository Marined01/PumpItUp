using PumpItUP.Models;

namespace PumpItUP.DAL.Repositories;

public interface IPostRepository
{
    Task CreatePostAsync(Post post);
}

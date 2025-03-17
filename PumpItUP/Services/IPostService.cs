using PumpItUP.Models;
using System.Threading.Tasks;

namespace PumpItUP.Services
{
    public interface IPostService
    {
        Task CreatePostAsync(CreatePostViewModel model, long userId);
    }
}

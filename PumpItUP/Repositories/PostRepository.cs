using PumpItUP.Models;
using System.Threading.Tasks;

namespace PumpItUP.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }
    }
}

using PumpItUp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PumpItUp.DAL.Repositories.Interfaces
{
    public interface IAttachmentRepository
    {
        Task<Attachment> GetByIdAsync(long attachmentId);
        // Task<IEnumerable<Attachment>> GetAllAsync();
        // Task AddAsync(Attachment attachment);
        // Task UpdateAsync(Attachment attachment);
        // Task DeleteAsync(long attachmentId);
    }
}
using Microsoft.EntityFrameworkCore;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.Exceptions;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Interfaces;

namespace PumpItUp.DAL.Repositories.Implementations
{
    public class AttachmentRepository(AppDbContext context) : IAttachmentRepository
    {
        public async Task<Attachment> GetByIdAsync(long attachmentId)
        {
            var attachment = await context.Attachments
                .FirstOrDefaultAsync(a => a.Id == attachmentId);

            if (attachment == null)
            {
                throw new AttachmentNotFoundException($"Attachment with ID=[{attachmentId}] not found.", attachmentId);
            }

            return attachment;
        }
    }
}
using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Services
{
    public class AttachmentService
    {
        private readonly AppDbContext _context;
        private readonly AttachmentMapper _attachmentMapper;

        public AttachmentService(AppDbContext context)
        {
            _context = context;
            _attachmentMapper = new AttachmentMapper();
        }

        public async Task<Attachment> CreateAttachmentAsync(AttachmentRequest attachmentRequest)
        {
            Attachment attachment = _attachmentMapper.MapToAttachment(attachmentRequest);
            _context.Attachments.Add(attachment);
            await _context.SaveChangesAsync();

            return attachment;
        }
    }
}
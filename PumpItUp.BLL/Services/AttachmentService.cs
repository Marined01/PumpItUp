using Microsoft.EntityFrameworkCore;
using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Implementations;

namespace PumpItUp.BLL.Services;

public class AttachmentService
{
    private readonly AppDbContext _context;
    private readonly AttachmentMapper _attachmentMapper;
    private readonly AttachmentRepository _attachmentRepository;

    public AttachmentService(AppDbContext context)
    {
        _context = context;
        _attachmentMapper = new AttachmentMapper();
        _attachmentRepository = new AttachmentRepository(_context);
    }

    public async Task<Attachment> CreateAttachmentAsync(AttachmentRequest attachmentRequest)
    {
        var attachment = _attachmentMapper.MapToAttachment(attachmentRequest);
        _context.Attachments.Add(attachment);
        await _context.SaveChangesAsync();

        return attachment;
    }

    public async Task<Attachment> GetAttachmentByIdAsync(long userId)
    {
        return await _attachmentRepository.GetByIdAsync(userId);
    }

    public async Task<List<Attachment>> GetAllAttachments()
    {
        return await _context.Attachments.ToListAsync();
    }
}
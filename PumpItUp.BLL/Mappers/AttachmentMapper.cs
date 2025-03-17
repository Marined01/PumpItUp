using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Mappers
{
    public class AttachmentMapper
    {
        public Attachment MapToAttachment(AttachmentRequest attachmentRequest)
        {
            return new Attachment
            {
                FileUrl = attachmentRequest.FileUrl,
                FileType = attachmentRequest.FileType,
                CreatedAt = attachmentRequest.CreatedAt,
                UpdatedAt = attachmentRequest.UpdatedAt,
                PostId = attachmentRequest.PostId
            };
        }
    }
}
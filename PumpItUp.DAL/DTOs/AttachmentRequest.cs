using System.ComponentModel.DataAnnotations;
using PumpItUp.DAL.Common;

namespace PumpItUp.DAL.DTOs
{
    public class AttachmentRequest
    {
        [Required]
        public string? FileUrl { get; set; }

        [Required]
        public FileType FileType { get; set; }

        [Required]
        public long PostId { get; set; }
    }
}
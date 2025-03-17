using System;

namespace PumpItUP.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long Likes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long PostedBy { get; set; }
        public long? AttachmentId { get; set; }
    }
}

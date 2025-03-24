namespace PumpItUp.DAL.DTOs;

public class PostRequest
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public int? PostedBy { get; set; }
    public int? AttachmentId { get; set; }
}
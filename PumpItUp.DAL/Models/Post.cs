namespace PumpItUP.Models;

public class Post
{
    public int Id { get; set; }  
    public required string Title { get; set; }
    public required string Content { get; set; }
    public int? Likes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int PostedBy { get; set; }
    public int? AttachmentId { get; set; }
}

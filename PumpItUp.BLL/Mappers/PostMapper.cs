using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;

namespace PumpItUp.BLL.Mappers;

public class PostMapper
{
    public Post MapToPost(PostRequest userRequest)
    {
        return new Post
        {
            Title = userRequest.Title,
            Content = userRequest.Content,
            PostedBy = userRequest.PostedBy ?? 0,
            AttachmentId = userRequest.AttachmentId
        };
    }
}
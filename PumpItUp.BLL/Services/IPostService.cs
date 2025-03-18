using PumpItUP.DAL.DTOs;

namespace PumpItUP.BLL.Services;

public interface IPostService
{
    Task CreatePostAsync(PostRequest postRequest);
}
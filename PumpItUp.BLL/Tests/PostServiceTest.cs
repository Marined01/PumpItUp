// using Moq;
// using PumpItUP.BLL.Services;
// using PumpItUP.DAL.DTOs;
// using PumpItUp.DAL.Models;
// using PumpItUp.DAL.Repositories.Interfaces;
// using Xunit;
//
// public class PostServiceTests
// {
//     [Fact]
//     public async Task CreatePostAsync_ShouldCreatePost()
//     {
//         var mockRepo = new Mock<IPostRepository>();
//         var mockLogger = new Mock<ILogger<PostService>>();
//
//         var postService = new PostService(mockRepo.Object, mockLogger.Object);
//
//         var request = new PostRequest
//         {
//             Title = "Test Post",
//             Content = "Test Content",
//             PostedBy = 1,
//             AttachmentId = null
//         };
//
//         // Act
//         await postService.CreatePostAsync(request);
//
//         // Assert
//         mockRepo.Verify(r => r.CreatePostAsync(It.Is<Post>(p => p.Title == "Test Post" && p.Content == "Test Content")), Times.Once);
//     }
// }
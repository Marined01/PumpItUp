using Xunit;
using Moq;
using PumpItUP.Services;
using PumpItUP.Repositories;
using PumpItUP.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PumpItUP.Tests
{
    public class PostServiceTests
    {
        [Fact]
        public async Task CreatePostAsync_ValidData_CreatesPostSuccessfully()
        {
            // Arrange
            var repoMock = new Mock<IPostRepository>();
            var loggerMock = new Mock<ILogger<PostService>>();
            var service = new PostService(repoMock.Object, loggerMock.Object);

            var model = new CreatePostViewModel { Title = "Test", Content = "Content" };
            long userId = 1;

            // Act
            await service.CreatePostAsync(model, userId);

            // Assert
            repoMock.Verify(r => r.AddPostAsync(It.IsAny<Post>()), Times.Once);
        }

        [Fact]
        public async Task CreatePostAsync_RepositoryThrows_ExceptionPropagates()
        {
            // Arrange
            var repoMock = new Mock<IPostRepository>();
            repoMock.Setup(r => r.AddPostAsync(It.IsAny<Post>())).ThrowsAsync(new System.Exception("DB error"));

            var loggerMock = new Mock<ILogger<PostService>>();
            var service = new PostService(repoMock.Object, loggerMock.Object);

            var model = new CreatePostViewModel { Title = "Test", Content = "Content" };
            long userId = 1;

            // Act & Assert
            await Assert.ThrowsAsync<System.Exception>(() => service.CreatePostAsync(model, userId));
        }
    }
}

using Moq;
using NUnit.Framework;
using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;
using PumpItUp.BLL.Services;
using Microsoft.EntityFrameworkCore;
using PumpItUp.DAL.Common;

namespace PumpItUp.BLL.Tests
{
    [TestFixture]
    public class UserServiceTest
    {
        private Mock<AppDbContext> _mockContext;
        private Mock<UserMapper> _mockUserMapper;
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _mockUserMapper = new Mock<UserMapper>();
            _userService = new UserService(_mockContext.Object);
        }

        [Test]
        public async Task CreateUserAsync_ShouldAddUserToDatabase()
        {
            var userRequest = new UserRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "Password123",
                AvatarUrl = "http://example.com/avatar.jpg",
                FitnessLevel = FitnessLevel.Beginner,
                Age = 25,
                Sex = Sex.Male,
                HasPremiumSubscription = false,
                Role = Role.UserRole,
                FollowingId = 1
            };

            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "Password123",
                AvatarUrl = "http://example.com/avatar.jpg",
                FitnessLevel = FitnessLevel.Beginner,
                Age = 25,
                Sex = Sex.Male,
                HasPremiumSubscription = false,
                Role = Role.UserRole,
                FollowingId = 1
            };

            _mockUserMapper.Setup(m => m.MapToUser(userRequest)).Returns(user);
            _mockContext.Setup(c => c.Users.Add(It.IsAny<User>()));
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var result = await _userService.CreateUserAsync(userRequest);

            _mockUserMapper.Verify(m => m.MapToUser(userRequest), Times.Once);
            _mockContext.Verify(c => c.Users.Add(It.Is<User>(u => u.Email == user.Email)), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
            Assert.AreEqual(user.Email, result.Email);
        }
    }
}
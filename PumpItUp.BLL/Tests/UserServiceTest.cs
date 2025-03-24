using Moq;
using NUnit.Framework;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using PumpItUp.DAL.Common;
using PumpItUp.DAL.DTOs;

namespace PumpItUp.BLL.Tests
{
    public class UserServiceTest
    {
        private Mock<UserRepository> _mockUserRepository;
        private Mock<AppDbContext> _mockContext;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _mockUserRepository = new Mock<UserRepository>(_mockContext.Object);

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
                FitnessLevel = FitnessLevel.Beginner,
                Age = 30,
                Sex = Sex.Male,
                HasPremiumSubscription = true,
                RoleId = 1,
                FollowingId = 1
            };

            var user = new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "Password123",
                FitnessLevel = FitnessLevel.Beginner,
                Age = 30,
                Sex = Sex.Male,
                HasPremiumSubscription = true,
                RoleId = 1,
                FollowingId = 1
            };

            // Mock the database operation
            _mockContext.Setup(c => c.Users.Add(It.IsAny<User>())).Verifiable();
            _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var createdUser = await _userService.CreateUserAsync(userRequest);

            // Assert
            Assert.IsNotNull(createdUser);
            Assert.AreEqual(userRequest.FirstName, createdUser.FirstName);
            _mockContext.Verify(c => c.Users.Add(It.IsAny<User>()), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task GetUserByIdAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            long userId = 1;
            var user = new User
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "Password123",
                FitnessLevel = FitnessLevel.Beginner,
                Age = 30,
                Sex = Sex.Male,
                HasPremiumSubscription = true,
                RoleId = 1,
                FollowingId = 1
            };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByIdAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.Id);
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("Doe", result.LastName);
        }

        [Test]
        public async Task GetAllUsers_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, FirstName = "John", LastName = "Doe" },
                new User { Id = 2, FirstName = "Jane", LastName = "Doe" }
            };

            _mockContext.Setup(c => c.Users.ToListAsync(It.IsAny<CancellationToken>())).ReturnsAsync(users);
            // Act
            var result = await _userService.GetAllUsers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("John", result[0].FirstName);
            Assert.AreEqual("Jane", result[1].FirstName);
        }
    }
}

using Moq;
using NUnit.Framework;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;
using PumpItUp.BLL.Services;
using Microsoft.EntityFrameworkCore;

namespace PumpItUp.BLL.Tests
{
    [TestFixture]
    public class RoleServiceTest
    {
        private Mock<AppDbContext> _mockContext = null!;
        private RoleService _roleService = null!;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _roleService = new RoleService(_mockContext.Object);
        }

        [Test]
        public async Task CreateRoleAsync_ShouldAddRoleToDatabase()
        {
            // Arrange
            var roleRequest = new RoleRequest
            {
                Name = "Admin",
                UserId = 1
            };

            var expectedRoleName = roleRequest.Name;

            // Setup mocks for DbContext
            _mockContext.Setup(c => c.Roles.Add(It.IsAny<Role>()));
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _roleService.CreateRoleAsync(roleRequest);

            // Assert
            _mockContext.Verify(c => c.Roles.Add(It.Is<Role>(r => r.Name == expectedRoleName)), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
            Assert.That(result.Name, Is.EqualTo(expectedRoleName));
        }
    }
}
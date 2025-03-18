using Moq;
using NUnit.Framework;
using PumpItUp.BLL.Mappers;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.DTOs;
using PumpItUp.DAL.Models;
using PumpItUp.BLL.Services;
using Microsoft.EntityFrameworkCore;

namespace PumpItUp.BLL.Tests
{
    [TestFixture]
    public class AttachmentServiceTest
    {
        private Mock<AppDbContext> _mockContext;
        private Mock<AttachmentMapper> _mockAttachmentMapper;
        private AttachmentService _attachmentService;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _mockAttachmentMapper = new Mock<AttachmentMapper>();
            _attachmentService = new AttachmentService(_mockContext.Object);
        }

        [Test]
        public async Task CreateAttachmentAsync_ShouldAddAttachmentToDatabase()
        {
            var attachmentRequest = new AttachmentRequest
            {
                
            };

            var attachment = new Attachment
            {
            };

            _mockAttachmentMapper.Setup(m => m.MapToAttachment(attachmentRequest)).Returns(attachment);
            _mockContext.Setup(c => c.Attachments.Add(It.IsAny<Attachment>()));
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var result = await _attachmentService.CreateAttachmentAsync(attachmentRequest);

            _mockAttachmentMapper.Verify(m => m.MapToAttachment(attachmentRequest), Times.Once);
            _mockContext.Verify(c => c.Attachments.Add(It.Is<Attachment>(a => a == attachment)), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
            Assert.AreEqual(attachment, result);
        }
    }
}
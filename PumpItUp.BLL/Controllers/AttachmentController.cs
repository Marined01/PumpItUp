using Microsoft.AspNetCore.Mvc;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.DTOs;

namespace PumpItUp.BLL.Controllers
{
    public class AttachmentController : Controller
    {
        private readonly AttachmentService _attachmentService;

        public AttachmentController(AttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        [HttpGet]
        public IActionResult CreateAttachment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttachment([FromForm] AttachmentRequest attachmentRequest)
        {
            await _attachmentService.CreateAttachmentAsync(attachmentRequest);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAttachmentById(int attachmentId)
        {
            var attachment = await _attachmentService.GetAttachmentByIdAsync(attachmentId);

            return View("AttachmentDetails", attachment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttachments()
        {
            var attachments = await _attachmentService.GetAllAttachments();
            return View(attachments);
        }
    }
}
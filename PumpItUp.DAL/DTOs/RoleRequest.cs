using System.ComponentModel.DataAnnotations;

namespace PumpItUp.DAL.DTOs
{
    public class RoleRequest
    {
        [Required]
        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public long UserId { get; set; }
    }
}
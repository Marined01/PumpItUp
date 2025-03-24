using System.ComponentModel.DataAnnotations;

namespace PumpItUp.DAL.DTOs
{
    public class RoleRequest
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}
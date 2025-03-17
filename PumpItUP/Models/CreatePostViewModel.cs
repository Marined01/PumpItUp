using System.ComponentModel.DataAnnotations;

namespace PumpItUP.Models
{
    public class CreatePostViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}

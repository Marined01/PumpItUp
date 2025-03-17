using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PumpItUp.DAL.Common;

namespace PumpItUp.DAL.Models;

[Table("attachment")]
public class Attachment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; set; }

    [Required]
    [Url]
    public string? FileUrl { get; set; }

    [Required]
    public FileType FileType { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public long PostId { get; set; }
}
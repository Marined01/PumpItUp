using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PumpItUp.DAL.Models;

[Table("following")]
public class Following
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; set; }

    [Required]
    [Column("user_one_id")]
    public long follower { get; set; }

    [Required]
    [Column("user_one_followed_by_id")]
    public long following { get; set; }

    [Column("crete_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("update_at")]
    public DateTime UpdatedAt { get; set; }

}
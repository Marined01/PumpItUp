using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PumpItUp.DAL.Common;

namespace PumpItUp.DAL.Models
{
    [Table("exercises")]
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public BodyPart BodyPart { get; set; }
        
        [Required]
        public ExerciseType Type { get; set; }
        
        [Required]
        public FitnessLevel DifficultyLevel { get; set; }
        
        [Required]
        public double CaloriesBurnedPerMinute { get; set; }
        
        // Foreign key for ExerciseSet
        public long ExerciseSetId { get; set; }
        
        // Navigation property
        [ForeignKey("ExerciseSetId")]
        public ExerciseSet? ExerciseSet { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
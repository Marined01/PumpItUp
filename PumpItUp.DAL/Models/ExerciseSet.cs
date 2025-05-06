using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PumpItUp.DAL.Common;

namespace PumpItUp.DAL.Models
{
    [Table("exercise_sets")]
    public class ExerciseSet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        [Url]
        public string ImageUrl { get; set; }
        
        [Url]
        public string? VideoUrl { get; set; }
        
        [Required]
        public int TrainingDurationMinutes { get; set; }
        
        [Required]
        public int CaloriesBurned { get; set; }
        
        [Required]
        public int NumberOfExercises { get; set; }
        
        [Required]
        public int Ratings { get; set; }
        
        [Required]
        public BodyPart PrimaryBodyPart { get; set; }
        
        [Required]
        public FitnessLevel DifficultyLevel { get; set; }
        
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
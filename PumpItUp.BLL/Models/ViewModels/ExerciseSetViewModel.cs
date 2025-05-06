using PumpItUp.DAL.Common;

namespace PumpItUp.BLL.Models.ViewModels
{
    public class ExerciseSetViewModel
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public int TrainingDurationMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public int NumberOfExercises { get; set; }
        public int Ratings { get; set; }
        public BodyPart PrimaryBodyPart { get; set; }
        public FitnessLevel DifficultyLevel { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; } = new List<ExerciseViewModel>();
    }
}
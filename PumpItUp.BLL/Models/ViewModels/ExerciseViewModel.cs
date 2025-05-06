using PumpItUp.DAL.Common;

namespace PumpItUp.BLL.Models.ViewModels
{
    public class ExerciseViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public BodyPart BodyPart { get; set; }
        public ExerciseType Type { get; set; }
        public FitnessLevel DifficultyLevel { get; set; }
        public double CaloriesBurnedPerMinute { get; set; }
    }
}
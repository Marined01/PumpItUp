using PumpItUp.DAL.Common;

namespace PumpItUp.BLL.Models.ViewModels
{
    public class ExerciseFilterViewModel
    {
        public List<BodyPart> SelectedBodyParts { get; set; } = new List<BodyPart>();
        public List<FitnessLevel> SelectedDifficultyLevels { get; set; } = new List<FitnessLevel>();
        public List<ExerciseType> SelectedExerciseTypes { get; set; } = new List<ExerciseType>();
        public string FilterType { get; set; } = "All";
    }
}
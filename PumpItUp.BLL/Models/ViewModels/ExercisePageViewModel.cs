namespace PumpItUp.BLL.Models.ViewModels
{
    public class ExercisePageViewModel
    {
        public List<ExerciseSetViewModel> ExerciseSets { get; set; } = new List<ExerciseSetViewModel>();
        public ExerciseFilterViewModel Filter { get; set; } = new ExerciseFilterViewModel();
    }
}
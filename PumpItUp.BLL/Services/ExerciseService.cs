using PumpItUp.BLL.Models.ViewModels;
using PumpItUp.DAL.Common;
using PumpItUp.DAL.Models;
using PumpItUp.DAL.Repositories;

namespace PumpItUp.BLL.Services
{
    public class ExerciseService
    {
        private readonly ExerciseSetRepository _exerciseSetRepository;

        public ExerciseService(ExerciseSetRepository exerciseSetRepository)
        {
            _exerciseSetRepository = exerciseSetRepository;
        }

        public async Task<ExercisePageViewModel> GetExercisesPageAsync(ExerciseFilterViewModel? filter = null)
        {
            if (filter == null)
            {
                filter = new ExerciseFilterViewModel();
            }

            var exerciseSets = await _exerciseSetRepository.GetFilteredAsync(
                filter.SelectedBodyParts,
                filter.SelectedDifficultyLevels,
                filter.SelectedExerciseTypes,
                filter.FilterType);

            var viewModel = new ExercisePageViewModel
            {
                ExerciseSets = exerciseSets.Select(MapToViewModel).ToList(),
                Filter = filter
            };

            return viewModel;
        }

        public async Task<ExerciseSetViewModel?> GetExerciseSetByIdAsync(long id)
        {
            var exerciseSet = await _exerciseSetRepository.GetByIdAsync(id);
            return exerciseSet != null ? MapToViewModel(exerciseSet) : null;
        }

        private ExerciseSetViewModel MapToViewModel(ExerciseSet exerciseSet)
        {
            return new ExerciseSetViewModel
            {
                Id = exerciseSet.Id,
                Title = exerciseSet.Title,
                Description = exerciseSet.Description,
                ImageUrl = exerciseSet.ImageUrl,
                VideoUrl = exerciseSet.VideoUrl,
                TrainingDurationMinutes = exerciseSet.TrainingDurationMinutes,
                CaloriesBurned = exerciseSet.CaloriesBurned,
                NumberOfExercises = exerciseSet.NumberOfExercises,
                PrimaryBodyPart = exerciseSet.PrimaryBodyPart,
                DifficultyLevel = exerciseSet.DifficultyLevel,
                Exercises = exerciseSet.Exercises.Select(e => new ExerciseViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    BodyPart = e.BodyPart,
                    Type = e.Type,
                    DifficultyLevel = e.DifficultyLevel,
                    CaloriesBurnedPerMinute = e.CaloriesBurnedPerMinute
                }).ToList()
            };
        }
    }
}
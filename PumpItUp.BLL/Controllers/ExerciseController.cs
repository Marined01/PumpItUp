using Microsoft.AspNetCore.Mvc;
using PumpItUp.BLL.Models.ViewModels;
using PumpItUp.BLL.Services;
using PumpItUp.DAL.Common;

namespace PumpItUp.BLL.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public async Task<IActionResult> Index(ExerciseFilterViewModel filter = null)
        {
            var model = await _exerciseService.GetExercisesPageAsync(filter);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var model = await _exerciseService.GetExerciseSetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(ExerciseFilterViewModel filter)
        {
            return RedirectToAction(nameof(Index), filter);
        }
    }
}
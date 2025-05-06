using Microsoft.EntityFrameworkCore;
using PumpItUp.DAL.Common;
using PumpItUp.DAL.Configuration;
using PumpItUp.DAL.Models;

namespace PumpItUp.DAL.Repositories
{
    public class ExerciseSetRepository
    {
        private readonly AppDbContext _context;

        public ExerciseSetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseSet>> GetAllAsync()
        {
            return await _context.ExerciseSets
                .Include(es => es.Exercises)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExerciseSet>> GetFilteredAsync(
            IEnumerable<BodyPart> bodyParts = null,
            IEnumerable<FitnessLevel> difficultyLevels = null,
            IEnumerable<ExerciseType> exerciseTypes = null,
            string filterType = "All")
        {
            var query = _context.ExerciseSets
                .Include(es => es.Exercises)
                .AsQueryable();

            if (bodyParts != null && bodyParts.Any())
            {
                query = query.Where(es => bodyParts.Contains(es.PrimaryBodyPart));
            }

            if (difficultyLevels != null && difficultyLevels.Any())
            {
                query = query.Where(es => difficultyLevels.Contains(es.DifficultyLevel));
            }

            if (exerciseTypes != null && exerciseTypes.Any() && filterType != "All")
            {
                query = query.Where(es => es.Exercises.Any(e => exerciseTypes.Contains(e.Type)));
            }

            return await query.ToListAsync();
        }

        public async Task<ExerciseSet> GetByIdAsync(long id)
        {
            return await _context.ExerciseSets
                .Include(es => es.Exercises)
                .FirstOrDefaultAsync(es => es.Id == id);
        }

        public async Task<ExerciseSet> CreateAsync(ExerciseSet exerciseSet)
        {
            _context.ExerciseSets.Add(exerciseSet);
            await _context.SaveChangesAsync();
            return exerciseSet;
        }

        public async Task<ExerciseSet> UpdateAsync(ExerciseSet exerciseSet)
        {
            _context.ExerciseSets.Update(exerciseSet);
            await _context.SaveChangesAsync();
            return exerciseSet;
        }

        public async Task DeleteAsync(long id)
        {
            var exerciseSet = await _context.ExerciseSets.FindAsync(id);
            if (exerciseSet != null)
            {
                _context.ExerciseSets.Remove(exerciseSet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
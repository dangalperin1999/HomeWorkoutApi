using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly FitnessContext _context;
        public ExerciseRepository(FitnessContext context)
        {
            _context = context;
        }
        public async Task<Exercise> Create(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task Delete(string id)
        {
            var exerciseToDelete = await _context.Exercises.FindAsync(id);
            _context.Exercises.Remove(exerciseToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> Get()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> Get(string id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task Update(Exercise exercise)
        {
            _context.Entry(exercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

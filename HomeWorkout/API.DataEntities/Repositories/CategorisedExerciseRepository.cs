using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class CategorisedExerciseRepository : ICategorisedExerciseRepository
    {
        private readonly FitnessContext _context;
        public CategorisedExerciseRepository(FitnessContext context)
        {
            _context = context;
        }
        public async Task<CategorisedExercise> Create(CategorisedExercise categorisedExercise)
        {
            _context.CategorisedExercises.Add(categorisedExercise);
            await _context.SaveChangesAsync();
            return categorisedExercise;
        }

        public async Task Delete(long id)
        {
            var categorisedExerciseToDelete = await _context.CategorisedExercises.FindAsync(id);
            _context.CategorisedExercises.Remove(categorisedExerciseToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategorisedExercise>> Get()
        {
            return await _context.CategorisedExercises.ToListAsync();
        }

        public async Task<CategorisedExercise> Get(long id)
        {
            return await _context.CategorisedExercises.FindAsync(id);
        }

        public async Task Update(CategorisedExercise categorisedExercise)
        {
            _context.Entry(categorisedExercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

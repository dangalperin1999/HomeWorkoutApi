using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class FitnessLevelRepository : IFitnessLevelRepository
    {
        private readonly FitnessContext _context;
        public FitnessLevelRepository(FitnessContext context)
        {
            _context = context;
        }

        public async Task<FitnessLevel> Create(FitnessLevel fitnessLevel)
        {
            _context.FitnessLevels.Add(fitnessLevel);
            await _context.SaveChangesAsync();
            return fitnessLevel;
        }

        public async Task Delete(string id)
        {
            var fitnessLevelToDelete = await _context.FitnessLevels.FindAsync(id);
            _context.FitnessLevels.Remove(fitnessLevelToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FitnessLevel>> Get()
        {
            return await _context.FitnessLevels.ToListAsync();
        }

        public async Task<FitnessLevel> Get(string id)
        {
            return await _context.FitnessLevels.FindAsync(id);
        }

        public async Task Update(FitnessLevel fitnessLevel)
        {
            _context.Entry(fitnessLevel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

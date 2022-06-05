using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class FitnessGoalRepository : IFitnessGoalRepository
    {
        private readonly FitnessContext _context;
        public FitnessGoalRepository(FitnessContext context)
        {
            _context = context;
        }
        public async Task<FitnessGoal> Create(FitnessGoal fitnessGoal)
        {
            _context.FitnessGoals.Add(fitnessGoal);
            await _context.SaveChangesAsync();
            return fitnessGoal;
        }

        public async Task Delete(string id)
        {
            var fitnessGoalToDelete = await _context.FitnessGoals.FindAsync(id);
            _context.FitnessGoals.Remove(fitnessGoalToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FitnessGoal>> Get()
        {
            return await _context.FitnessGoals.ToListAsync();
        }

        public async Task<FitnessGoal> Get(string id)
        {
            return await _context.FitnessGoals.FindAsync(id);
        }

        public async Task Update(FitnessGoal fitnessGoal)
        {
            _context.Entry(fitnessGoal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

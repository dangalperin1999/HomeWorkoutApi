using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class UserWorkoutPlanRepository : IUserWorkoutPlanRepository
    {
        private readonly FitnessContext _context;
        public UserWorkoutPlanRepository(FitnessContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserWorkoutPlan>> Get()
        {
            return await _context.UserWorkoutPlans.ToListAsync();
        }

        public async Task<UserWorkoutPlan> Get(long id)
        {
            return await _context.UserWorkoutPlans.FindAsync(id);
        }

        public async Task<UserWorkoutPlan> Create(UserWorkoutPlan userWorkoutPlan)
        {
            _context.UserWorkoutPlans.Add(userWorkoutPlan);
            await _context.SaveChangesAsync();
            return userWorkoutPlan;
        }

        public async Task Update(UserWorkoutPlan userWorkoutPlan)
        {
            _context.Entry(userWorkoutPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var userWorkoutPlanToDelete = await _context.UserWorkoutPlans.FindAsync(id);
            _context.UserWorkoutPlans.Remove(userWorkoutPlanToDelete);
            await _context.SaveChangesAsync();
        }
    }
}

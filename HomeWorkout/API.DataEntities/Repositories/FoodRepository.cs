using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FitnessContext _context;
        public FoodRepository(FitnessContext context)
        {
            _context = context;
        }
        public async Task<Food> Create(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task Delete(string id)
        {
            var foodToDelete = await _context.Foods.FindAsync(id);
            _context.Foods.Remove(foodToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Food>> Get()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food> Get(string id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public async Task Update(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

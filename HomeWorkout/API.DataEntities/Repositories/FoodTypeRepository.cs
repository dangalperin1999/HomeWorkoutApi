using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class FoodTypeRepository : IFoodTypeRepository
    {
        private readonly FitnessContext _context;
        public FoodTypeRepository(FitnessContext context)
        {
            _context = context;
        }
        public async Task<FoodType> Create(FoodType foodType)
        {
            _context.FoodTypes.Add(foodType);
            await _context.SaveChangesAsync();
            return foodType;
        }

        public async Task Delete(string id)
        {
            var foodTypeToDelete = await _context.FoodTypes.FindAsync(id);
            _context.FoodTypes.Remove(foodTypeToDelete);
            await _context.SaveChangesAsync();
        }
    
        public async Task<IEnumerable<FoodType>> Get()
        {
            return await _context.FoodTypes.ToListAsync();
        }

        public async Task<FoodType> Get(string id)
        {
            return await _context.FoodTypes.FindAsync(id);
        }

        public async Task Update(FoodType foodType)
        {
            _context.Entry(foodType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

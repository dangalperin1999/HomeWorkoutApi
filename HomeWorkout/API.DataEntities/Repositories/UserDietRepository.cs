using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class UserDietRepository : IUserDietRepository
    {
        private readonly FitnessContext _context;
        public UserDietRepository(FitnessContext context)
        {
            _context = context;
        }
        public async Task<UserDiet> Create(UserDiet userDiet)
        {
            _context.UserDiets.Add(userDiet);
            await _context.SaveChangesAsync();
            return userDiet;
        }

        public async Task Delete(long id)
        {
            var userDietToDelete = await _context.UserDiets.FindAsync(id);
            _context.UserDiets.Remove(userDietToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDiet>> Get()
        {
            return await _context.UserDiets.ToListAsync();
        }

        public async Task<UserDiet> Get(long id)
        {
            return await _context.UserDiets.FindAsync(id);
        }

        public async Task Update(UserDiet userDiet)
        {
            _context.Entry(userDiet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

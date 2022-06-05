using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class UserDieryRepository : IUserDieryRepository
    {
        private readonly FitnessContext _context;
        public UserDieryRepository(FitnessContext context)
        {
            _context = context;
        }
        public async Task<UserDiery> Create(UserDiery userDiery)
        {
            _context.UserDieries.Add(userDiery);
            await _context.SaveChangesAsync();
            return userDiery;
        }

        public async Task Delete(long id)
        {
            var userDieryToDelete = await _context.UserDieries.FindAsync(id);
            _context.UserDieries.Remove(userDieryToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDiery>> Get()
        {
            return await _context.UserDieries.ToListAsync();
        }

        public async Task<UserDiery> Get(long id)
        {
            return await _context.UserDieries.FindAsync(id);
        }

        public async Task Update(UserDiery userDiery)
        {
            _context.Entry(userDiery).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

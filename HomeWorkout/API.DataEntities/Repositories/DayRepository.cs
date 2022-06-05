using API.DataFitness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public class DayRepository : IDayRepository
    {
        private readonly FitnessContext _context;
        public DayRepository(FitnessContext context)
        {
            _context = context;
        }
        public async Task<Day> Create(Day day)
        {
            _context.Days.Add(day);
            await _context.SaveChangesAsync();
            return day;
        }

        public async Task Delete(string id)
        {
            var dayToDelete = await _context.Days.FindAsync(id);
            _context.Days.Remove(dayToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Day>> Get()
        {
            return await _context.Days.ToListAsync();
        }

        public async Task<Day> Get(string id)
        {
            return await _context.Days.FindAsync(id);
        }

        public async Task Update(Day day)
        {
            _context.Entry(day).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

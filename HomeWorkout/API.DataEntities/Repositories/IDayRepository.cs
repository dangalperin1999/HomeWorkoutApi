using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface IDayRepository
    {
        Task<IEnumerable<Day>> Get();
        Task<Day> Get(string id);
        Task<Day> Create(Day day);
        Task Update(Day day);
        Task Delete(string id);
    }
}

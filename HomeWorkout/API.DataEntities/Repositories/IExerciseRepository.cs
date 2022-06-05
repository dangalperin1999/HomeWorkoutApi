using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> Get();
        Task<Exercise> Get(string id);
        Task<Exercise> Create(Exercise exercise);
        Task Update(Exercise exercise);
        Task Delete(string id);
    }
}

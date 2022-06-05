using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface ICategorisedExerciseRepository
    {
        Task<IEnumerable<CategorisedExercise>> Get();
        Task<CategorisedExercise> Get(long id);
        Task<CategorisedExercise> Create(CategorisedExercise categorisedExercise);
        Task Update(CategorisedExercise categorisedExercise);
        Task Delete(long id);
    }
}

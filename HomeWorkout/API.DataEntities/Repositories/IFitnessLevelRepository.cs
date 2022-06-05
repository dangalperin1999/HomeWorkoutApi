using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface IFitnessLevelRepository
    {
        Task<IEnumerable<FitnessLevel>> Get();
        Task<FitnessLevel> Get(string id);
        Task<FitnessLevel> Create(FitnessLevel fitnessLevel);
        Task Update(FitnessLevel fitnessLevel);
        Task Delete(string id);
    }
}

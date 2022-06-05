using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface IFitnessGoalRepository
    {
        Task<IEnumerable<FitnessGoal>> Get();
        Task<FitnessGoal> Get(string id);
        Task<FitnessGoal> Create(FitnessGoal fitnessGoal);
        Task Update(FitnessGoal fitnessGoal);
        Task Delete(string id);
    }
}

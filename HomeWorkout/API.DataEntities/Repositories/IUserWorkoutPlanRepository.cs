using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface IUserWorkoutPlanRepository
    {
        Task<IEnumerable<UserWorkoutPlan>> Get();
        Task<UserWorkoutPlan> Get(long id);
        Task<UserWorkoutPlan> Create(UserWorkoutPlan userWorkoutPlan);
        Task Update(UserWorkoutPlan userWorkoutPlan);
        Task Delete(long id);
    }
}

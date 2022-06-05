using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface IUserDietRepository
    {
        Task<IEnumerable<UserDiet>> Get();
        Task<UserDiet> Get(long id);
        Task<UserDiet> Create(UserDiet userDiet);
        Task Update(UserDiet userDiet);
        Task Delete(long id);
    }
}

using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface IUserDieryRepository
    {
        Task<IEnumerable<UserDiery>> Get();
        Task<UserDiery> Get(long id);
        Task<UserDiery> Create(UserDiery userDiery);
        Task Update(UserDiery userDiery);
        Task Delete(long id);
    }
}

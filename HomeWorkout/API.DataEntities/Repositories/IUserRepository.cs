using API.DataFitness.Authenticators;
using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(long id);
        Task<User> Create(User user);
        Task Update(User user);
        Task Delete(long id);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}

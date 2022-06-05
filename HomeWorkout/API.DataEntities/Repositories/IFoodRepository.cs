using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> Get();
        Task<Food> Get(string id);
        Task<Food> Create(Food food);
        Task Update(Food food);
        Task Delete(string id);
    }
}

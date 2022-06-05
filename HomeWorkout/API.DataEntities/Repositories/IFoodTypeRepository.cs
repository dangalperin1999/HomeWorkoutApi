using API.DataFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataFitness.Repositories
{
    public interface IFoodTypeRepository
    {
        Task<IEnumerable<FoodType>> Get();
        Task<FoodType> Get(string id);
        Task<FoodType> Create(FoodType foodType);
        Task Update(FoodType foodType);
        Task Delete(string id);
    }
}

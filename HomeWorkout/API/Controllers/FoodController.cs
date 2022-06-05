using API.DataFitness.Models;
using API.DataFitness.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;

        public FoodController(IFoodRepository fitnessLevelRepository)
        {
            _foodRepository = fitnessLevelRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Food>> getFood()
        {
            return await _foodRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> getFood(string id)
        {
            return await _foodRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Food>> postFood([FromBody] Food food)
        {
            var newFood = await _foodRepository.Create(food);
            return CreatedAtAction(nameof(getFood), new { id = newFood.Name }, newFood);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putFood(string id, [FromBody] Food food)
        {
            if (id != food.Name)
            {
                return BadRequest();
            }

            await _foodRepository.Update(food);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteFood(string id)
        {
            var foodToDelete = await _foodRepository.Get(id);
            if (foodToDelete == null)
            {
                return NotFound();
            }
            await _foodRepository.Delete(foodToDelete.Name);
            return NoContent();
        }
    }
}

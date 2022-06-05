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
    public class FoodTypesController : ControllerBase
    {
        private readonly IFoodTypeRepository _FoodTypeRepository;

        public FoodTypesController(IFoodTypeRepository foodTypeRepository)
        {
            _FoodTypeRepository = foodTypeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<FoodType>> getFoodTypes()
        {
            return await _FoodTypeRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodType>> getFoodTypes(string id)
        {
            return await _FoodTypeRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<FoodType>> postFoodTypes([FromBody] FoodType foodType)
        {
            var newFoodType = await _FoodTypeRepository.Create(foodType);
            return CreatedAtAction(nameof(getFoodTypes), new { id = newFoodType.Name }, newFoodType);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putFoodTypes(string id, [FromBody] FoodType foodType)
        {
            if (id != foodType.Name)
            {
                return BadRequest();
            }

            await _FoodTypeRepository.Update(foodType);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteFoodTypes(string id)
        {
            var foodTypeToDelete = await _FoodTypeRepository.Get(id);
            if (foodTypeToDelete == null)
            {
                return NotFound();
            }
            await _FoodTypeRepository.Delete(foodTypeToDelete.Name);
            return NoContent();
        }
    }
}

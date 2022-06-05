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
    public class CategorisedExercisesController : ControllerBase
    {
        private readonly ICategorisedExerciseRepository _categorisedExerciseRepository;

        public CategorisedExercisesController(ICategorisedExerciseRepository categorisedExerciseRepository)
        {
            _categorisedExerciseRepository = categorisedExerciseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CategorisedExercise>> getCategorisedExercises()
        {
            return await _categorisedExerciseRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategorisedExercise>> getCategorisedExercises(long id)
        {
            return await _categorisedExerciseRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<CategorisedExercise>> postCategorisedExercises([FromBody] CategorisedExercise categorisedExercise)
        {
            var newCategorisedExercise = await _categorisedExerciseRepository.Create(categorisedExercise);
            return CreatedAtAction(nameof(getCategorisedExercises), new { id = newCategorisedExercise.CategoryExerciseId }, newCategorisedExercise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putCategorisedExercises(long id, [FromBody] CategorisedExercise categorisedExercise)
        {
            if (id != categorisedExercise.CategoryExerciseId)
            {
                return BadRequest();
            }

            await _categorisedExerciseRepository.Update(categorisedExercise);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteCategorisedExercises(long id)
        {
            var categorisedExerciseToDelete = await _categorisedExerciseRepository.Get(id);
            if (categorisedExerciseToDelete == null)
            {
                return NotFound();
            }
            await _categorisedExerciseRepository.Delete(categorisedExerciseToDelete.CategoryExerciseId);
            return NoContent();
        }
    }
}

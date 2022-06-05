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
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExercisesController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Exercise>> getExercises()
        {
            return await _exerciseRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> getExercises(string id)
        {
            return await _exerciseRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> postExercises([FromBody] Exercise exercise)
        {
            var newExercise = await _exerciseRepository.Create(exercise);
            return CreatedAtAction(nameof(getExercises), new { id = newExercise.Name }, newExercise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putExercises(string id, [FromBody] Exercise exercise)
        {
            if (id != exercise.Name)
            {
                return BadRequest();
            }

            await _exerciseRepository.Update(exercise);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteExercises(string id)
        {
            var exerciseToDelete = await _exerciseRepository.Get(id);
            if (exerciseToDelete == null)
            {
                return NotFound();
            }
            await _exerciseRepository.Delete(exerciseToDelete.Name);
            return NoContent();
        }
    }
}

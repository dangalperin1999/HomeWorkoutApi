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
    public class FitnessGoalsController : ControllerBase
    {
        private readonly IFitnessGoalRepository _fitnessGoalRepository;

        public FitnessGoalsController(IFitnessGoalRepository fitnessGoalRepository)
        {
            _fitnessGoalRepository = fitnessGoalRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<FitnessGoal>> getFitnessGoals()
        {
            return await _fitnessGoalRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessGoal>> getFitnessGoals(string id)
        {
            return await _fitnessGoalRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<FitnessGoal>> postFitnessGoals([FromBody] FitnessGoal fitnessGoal)
        {
            var newFitnessGoal = await _fitnessGoalRepository.Create(fitnessGoal);
            return CreatedAtAction(nameof(getFitnessGoals), new { id = newFitnessGoal.Name }, newFitnessGoal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putFitnessGoals(string id, [FromBody] FitnessGoal fitnessGoal)
        {
            if (id != fitnessGoal.Name)
            {
                return BadRequest();
            }

            await _fitnessGoalRepository.Update(fitnessGoal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteFitnessGoals(string id)
        {
            var fitnessGoalToDelete = await _fitnessGoalRepository.Get(id);
            if (fitnessGoalToDelete == null)
            {
                return NotFound();
            }
            await _fitnessGoalRepository.Delete(fitnessGoalToDelete.Name);
            return NoContent();
        }
    }
}

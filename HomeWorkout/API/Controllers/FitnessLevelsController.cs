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
    public class FitnessLevelsController : ControllerBase
    {
        private readonly IFitnessLevelRepository _fitnessLevelRepository;

        public FitnessLevelsController(IFitnessLevelRepository fitnessLevelRepository)
        {
            _fitnessLevelRepository = fitnessLevelRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<FitnessLevel>> getFitnessLevels()
        {
            return await _fitnessLevelRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessLevel>> getFitnessLevels(string id)
        {
            return await _fitnessLevelRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<FitnessLevel>> postFitnessLevels([FromBody] FitnessLevel fitnessLevel)
        {
            var newFitnessLevel = await _fitnessLevelRepository.Create(fitnessLevel);
            return CreatedAtAction(nameof(getFitnessLevels), new { id = newFitnessLevel.Name }, newFitnessLevel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putFitnessLevels(string id, [FromBody] FitnessLevel fitnessLevel)
        {
            if (id != fitnessLevel.Name)
            {
                return BadRequest();
            }

            await _fitnessLevelRepository.Update(fitnessLevel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteFitnessLevels(string id)
        {
            var fitnessLevelToDelete = await _fitnessLevelRepository.Get(id);
            if (fitnessLevelToDelete == null)
            {
                return NotFound();
            }
            await _fitnessLevelRepository.Delete(fitnessLevelToDelete.Name);
            return NoContent();
        }
    }
}

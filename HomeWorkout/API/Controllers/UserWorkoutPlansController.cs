using API.DataFitness.Models;
using API.DataFitness.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWorkoutPlansController : ControllerBase
    {
        private readonly IUserWorkoutPlanRepository _userWorkoutPlanRepository;

        public UserWorkoutPlansController(IUserWorkoutPlanRepository userWorkoutPlanRepository)
        {
            _userWorkoutPlanRepository = userWorkoutPlanRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserWorkoutPlan>> getUserWorkoutPlans()
        {
            return await _userWorkoutPlanRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserWorkoutPlan>> getUserWorkoutPlans(long id)
        {
            return await _userWorkoutPlanRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserWorkoutPlan>> postUserWorkoutPlans([FromBody] UserWorkoutPlan userWorkoutPlan)
        {
            var newUserWorkoutPlan = await _userWorkoutPlanRepository.Create(userWorkoutPlan);
            return CreatedAtAction(nameof(getUserWorkoutPlans), new { id = newUserWorkoutPlan.Id }, newUserWorkoutPlan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putUserWorkoutPlans(long id, [FromBody] UserWorkoutPlan userWorkoutPlan)
        {
            if (id != userWorkoutPlan.Id)
            {
                return BadRequest();
            }

            await _userWorkoutPlanRepository.Update(userWorkoutPlan);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteUserWorkoutPlans(long id)
        {
            var userWorkoutPlanToDelete = await _userWorkoutPlanRepository.Get(id);
            if (userWorkoutPlanToDelete == null)
            {
                return NotFound();
            }
            await _userWorkoutPlanRepository.Delete(userWorkoutPlanToDelete.Id);
            return NoContent();
        }

    }
}

using API.DataFitness.Models;
using API.DataFitness.Repositories;
using API.Repositories;
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
    public class UsersDietsController : ControllerBase
    {
        private readonly IUserDietRepository _userDietRepository;

        public UsersDietsController(IUserDietRepository userDietRepository)
        {
            _userDietRepository = userDietRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDiet>> getUserDiets()
        {
            return await _userDietRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDiet>> getUserDiets(long id)
        {
            return await _userDietRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserDiet>> postUserDiets([FromBody] UserDiet userDiet)
        {
            var newUserDiet = await _userDietRepository.Create(userDiet);
            return CreatedAtAction(nameof(getUserDiets), new { id = newUserDiet.Id }, newUserDiet);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putUserDiets(long id, [FromBody] UserDiet userDiet)
        {
            if (id != userDiet.Id)
            {
                return BadRequest();
            }

            await _userDietRepository.Update(userDiet);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteUserDiets(long id)
        {
            var userDietToDelete = await _userDietRepository.Get(id);
            if (userDietToDelete == null)
            {
                return NotFound();
            }
            await _userDietRepository.Delete(userDietToDelete.Id);
            return NoContent();
        }
    }
}

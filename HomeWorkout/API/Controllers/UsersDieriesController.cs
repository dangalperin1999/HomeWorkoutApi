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
    public class UsersDieriesController : ControllerBase
    {
        private readonly IUserDieryRepository _userDieryRepository;

        public UsersDieriesController(IUserDieryRepository userDieryRepository)
        {
            _userDieryRepository = userDieryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDiery>> getUsersDieries()
        {
            return await _userDieryRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDiery>> getUserDieries(long id)
        {
            return await _userDieryRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserDiery>> postUsersDieries([FromBody] UserDiery userDiery)
        {
            var newUserDiery = await _userDieryRepository.Create(userDiery);
            return CreatedAtAction(nameof(getUsersDieries), new { id = newUserDiery.Id }, newUserDiery);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putUsersDieries(long id, [FromBody] UserDiery userDiery)
        {
            if (id != userDiery.Id)
            {
                return BadRequest();
            }

            await _userDieryRepository.Update(userDiery);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteUsersDieries(long id)
        {
            var userDieryToDelete = await _userDieryRepository.Get(id);
            if (userDieryToDelete == null)
            {
                return NotFound();
            }
            await _userDieryRepository.Delete(userDieryToDelete.Id);
            return NoContent();
        }

    }
}

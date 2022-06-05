using API.DataFitness;
using API.DataFitness.Authenticators;
using API.DataFitness.Helpers;
using API.DataFitness.Models;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize]

        [HttpGet]
        public async Task<IEnumerable<User>> getUsers()
        {
            return await _userRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> getUsers(long id)
        {
            return await _userRepository.Get(id);
        }

        [HttpPost("authenticate")]

        public IActionResult Authenticate(AuthenticateRequest user)
        {
            var response = _userRepository.Authenticate(user);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<User>> postUsers(User user)
        {
            var newUser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(getUsers), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putUsers(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.Update(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteUsers(long id)
        {
            var userToDelete = await _userRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            await _userRepository.Delete(userToDelete.Id);
            return NoContent();
        }

    }
}

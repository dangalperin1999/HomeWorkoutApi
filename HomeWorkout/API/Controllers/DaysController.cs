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
    public class DaysController : ControllerBase
    {
        private readonly IDayRepository _dayRepository;

        public DaysController(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Day>> getDays()
        {
            return await _dayRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> getDays(string id)
        {
            return await _dayRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Day>> postDays([FromBody] Day day)
        {
            var newDay = await _dayRepository.Create(day);
            return CreatedAtAction(nameof(getDays), new { id = newDay.Name }, newDay);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> putDays(string id, [FromBody] Day day)
        {
            if (id != day.Name)
            {
                return BadRequest();
            }

            await _dayRepository.Update(day);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteDays(string id)
        {
            var dayToDelete = await _dayRepository.Get(id);
            if (dayToDelete == null)
            {
                return NotFound();
            }
            await _dayRepository.Delete(dayToDelete.Name);
            return NoContent();
        }
    }
}

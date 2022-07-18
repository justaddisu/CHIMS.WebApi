using CHIMS.WebApi.Models;
using CHIMS.WebApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedsController : ControllerBase
    {
        private readonly IBedRepository _bedRepository;

        public BedsController(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<Bed>>> GetBeds()
        {
            return await _bedRepository.GetBedsAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bed>> GetBed(int id)
        {
            var bed = await _bedRepository.GetBedAsync(id);

            if (bed == null)
            {
                return NotFound();
            }

            return bed;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBed([FromRoute] int id, [FromBody] Bed bed)
        {
            await _bedRepository.PutBedAsync(id, bed);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostBed([FromBody] Bed bed)
        {
            var id = await _bedRepository.PostBedAsync(bed);

            return CreatedAtAction(nameof(GetBed), new { id, controller = "Beds" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBed(int id)
        {
            await _bedRepository.DeleteBedAsync(id);
            return Ok();

        }
    }
}

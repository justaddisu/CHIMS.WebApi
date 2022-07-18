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
    public class WeredasController : ControllerBase
    {
        private readonly IWeredaRepository _weredaRepository;

        public WeredasController(IWeredaRepository weredaRepository)
        {
            _weredaRepository = weredaRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<Wereda>>> GetWeredas()
        {
            return await _weredaRepository.GetWeredasAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wereda>> GetWereda(int id)
        {
            var wereda = await _weredaRepository.GetWeredaAsync(id);

            if (wereda == null)
            {
                return NotFound();
            }

            return wereda;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWereda([FromRoute] int id, [FromBody] Wereda wereda)
        {            
            await _weredaRepository.PutWeredaAsync(id, wereda);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostWereda([FromBody] Wereda wereda)
        {
            var id = await _weredaRepository.PostWeredaAsync(wereda);

            return CreatedAtAction(nameof(GetWereda), new { id, controller = "weredas" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWereda(int id)
        {
            await _weredaRepository.DeleteWeredaAsync(id);
            return Ok();

        }


    }
}


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
    public class KebelesController : ControllerBase
    {

        private readonly IKebeleRepository _kebeleRepository;

        public KebelesController(IKebeleRepository kebeleRepository)
        {
            _kebeleRepository = kebeleRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<Kebele>>> GetKebeles()
        {
            return await _kebeleRepository.GetKebelesAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kebele>> GetKebele(int id)
        {
            var Kebele = await _kebeleRepository.GetKebeleAsync(id);

            if (Kebele == null)
            {
                return NotFound();
            }

            return Kebele;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKebele([FromRoute] int id, [FromBody] Kebele Kebele)
        {
            await _kebeleRepository.PutKebeleAsync(id, Kebele);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostKebele([FromBody] Kebele Kebele)
        {
            var id = await _kebeleRepository.PostKebeleAsync(Kebele);

            return CreatedAtAction(nameof(GetKebele), new { id, controller = "Kebeles" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKebele(int id)
        {
            await _kebeleRepository.DeleteKebeleAsync(id);
            return Ok();

        }
        
    }
}

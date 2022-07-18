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
    public class WardsController : ControllerBase
    {
        private readonly IWardRepository _wardRepository;

        public WardsController(IWardRepository wardRepository)
        {
            _wardRepository = wardRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<Ward>>> GetWards()
        {
            return await _wardRepository.GetWardsAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ward>> GetWard(int id)
        {
            var Ward = await _wardRepository.GetWardAsync(id);

            if (Ward == null)
            {
                return NotFound();
            }

            return Ward;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWard([FromRoute] int id, [FromBody] Ward Ward)
        {
            await _wardRepository.PutWardAsync(id, Ward);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostWard([FromBody] Ward Ward)
        {
            var id = await _wardRepository.PostWardAsync(Ward);

            return CreatedAtAction(nameof(GetWard), new { id, controller = "Wards" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWard(int id)
        {
            await _wardRepository.DeleteWardAsync(id);
            return Ok();

        }
    }
}

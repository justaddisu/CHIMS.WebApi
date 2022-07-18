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
    public class DrugsController : ControllerBase
    {
        private readonly IDrugRepository _drugRepository;

        public DrugsController(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<Drug>>> GetDrugs()
        {
            return await _drugRepository.GetDrugsAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrug(int id)
        {
            var Drug = await _drugRepository.GetDrugAsync(id);

            if (Drug == null)
            {
                return NotFound();
            }

            return Drug;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrug([FromRoute] int id, [FromBody] Drug Drug)
        {
            await _drugRepository.PutDrugAsync(id, Drug);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostDrug([FromBody] Drug Drug)
        {
            var id = await _drugRepository.PostDrugAsync(Drug);

            return CreatedAtAction(nameof(GetDrug), new { id, controller = "Drugs" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrug(int id)
        {
            await _drugRepository.DeleteDrugAsync(id);
            return Ok();

        }
    }
}

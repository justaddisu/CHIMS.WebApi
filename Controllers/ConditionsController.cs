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
    public class ConditionsController : ControllerBase
    {
        private readonly IConditionRepository _conditionRepository;

        public ConditionsController(IConditionRepository conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<Condition>>> GetConditions()
        {
            return await _conditionRepository.GetConditionsAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Condition>> GetCondition(int id)
        {
            var condition = await _conditionRepository.GetConditionAsync(id);

            if (condition == null)
            {
                return NotFound();
            }

            return condition;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondition([FromRoute] int id, [FromBody] Condition condition)
        {
            await _conditionRepository.PutConditionAsync(id, condition);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostCondition([FromBody] Condition condition)
        {
            var id = await _conditionRepository.PostConditionAsync(condition);

            return CreatedAtAction(nameof(GetCondition), new { id, controller = "Conditions" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondition(int id)
        {
            await _conditionRepository.DeleteConditionAsync(id);
            return Ok();

        }
    }
}

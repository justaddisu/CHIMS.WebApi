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
    public class BedExpensesController : ControllerBase
    {
        private readonly IBedExpenseRepository _bedExpenseRepository;

        public BedExpensesController(IBedExpenseRepository bedExpenseRepository)
        {
            _bedExpenseRepository = bedExpenseRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<BedExpense>>> GetBedExpenses()
        {
            return await _bedExpenseRepository.GetBedExpensesAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BedExpense>> GetBedExpense(int id)
        {
            var bedExpense = await _bedExpenseRepository.GetBedExpenseAsync(id);

            if (bedExpense == null)
            {
                return NotFound();
            }

            return bedExpense;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBedExpense([FromRoute] int id, [FromBody] BedExpense bedExpense)
        {
            await _bedExpenseRepository.PutBedExpenseAsync(id, bedExpense);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostBedExpense([FromBody] BedExpense bedExpense)
        {
            var id = await _bedExpenseRepository.PostBedExpenseAsync(bedExpense);

            return CreatedAtAction(nameof(GetBedExpense), new { id, controller = "BedExpenses" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBedExpense(int id)
        {
            await _bedExpenseRepository.DeleteBedExpenseAsync(id);
            return Ok();

        }
    }
}

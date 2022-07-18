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
    public class DrugExpensesController : ControllerBase
    {
        private readonly IDrugExpenseRepository _drugExpenseRepository;

        public DrugExpensesController(IDrugExpenseRepository drugExpenseRepository)
        {
            _drugExpenseRepository = drugExpenseRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<DrugExpense>>> GetDrugExpenses()
        {
            return await _drugExpenseRepository.GetDrugExpensesAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrugExpense>> GetDrugExpense(int id)
        {
            var DrugExpense = await _drugExpenseRepository.GetDrugExpenseAsync(id);

            if (DrugExpense == null)
            {
                return NotFound();
            }

            return DrugExpense;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrugExpense([FromRoute] int id, [FromBody] DrugExpense DrugExpense)
        {
            await _drugExpenseRepository.PutDrugExpenseAsync(id, DrugExpense);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostDrugExpense([FromBody] DrugExpense DrugExpense)
        {
            var id = await _drugExpenseRepository.PostDrugExpenseAsync(DrugExpense);

            return CreatedAtAction(nameof(GetDrugExpense), new { id, controller = "DrugExpenses" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrugExpense(int id)
        {
            await _drugExpenseRepository.DeleteDrugExpenseAsync(id);
            return Ok();

        }
    }
}

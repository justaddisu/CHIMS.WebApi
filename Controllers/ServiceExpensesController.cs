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
    public class ServiceExpensesController : ControllerBase
    {

        private readonly IServiceExpenseRepository _serviceExpenseRepository;

        public ServiceExpensesController(IServiceExpenseRepository serviceExpenseRepository)
        {
            _serviceExpenseRepository = serviceExpenseRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<ServiceExpense>>> GetServiceExpenses()
        {
            return await _serviceExpenseRepository.GetServiceExpensesAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceExpense>> GetServiceExpense(int id)
        {
            var ServiceExpense = await _serviceExpenseRepository.GetServiceExpenseAsync(id);

            if (ServiceExpense == null)
            {
                return NotFound();
            }

            return ServiceExpense;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceExpense([FromRoute] int id, [FromBody] ServiceExpense ServiceExpense)
        {
            await _serviceExpenseRepository.PutServiceExpenseAsync(id, ServiceExpense);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostServiceExpense([FromBody] ServiceExpense ServiceExpense)
        {
            var id = await _serviceExpenseRepository.PostServiceExpenseAsync(ServiceExpense);

            return CreatedAtAction(nameof(GetServiceExpense), new { id, controller = "ServiceExpenses" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceExpense(int id)
        {
            await _serviceExpenseRepository.DeleteServiceExpenseAsync(id);
            return Ok();

        }
    }
}

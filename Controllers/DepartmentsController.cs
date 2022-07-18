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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            return await _departmentRepository.GetDepartmentsAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var Department = await _departmentRepository.GetDepartmentAsync(id);

            if (Department == null)
            {
                return NotFound();
            }

            return Department;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment([FromRoute] int id, [FromBody] Department Department)
        {
            await _departmentRepository.PutDepartmentAsync(id, Department);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostDepartment([FromBody] Department Department)
        {
            var id = await _departmentRepository.PostDepartmentAsync(Department);

            return CreatedAtAction(nameof(GetDepartment), new { id, controller = "Departments" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
            return Ok();

        }
    }
}

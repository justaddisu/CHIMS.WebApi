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
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetServices()
        {
            return await _serviceRepository.GetServicesAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _serviceRepository.GetServiceAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService([FromRoute] int id, [FromBody] Service service)
        {
            await _serviceRepository.PutServiceAsync(id, service);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostService([FromBody] Service service)
        {
            var id = await _serviceRepository.PostServiceAsync(service);

            return CreatedAtAction(nameof(GetService), new { id, controller = "Services" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
            return Ok();

        }
    }
}

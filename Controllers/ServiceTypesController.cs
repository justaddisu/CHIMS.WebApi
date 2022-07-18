using CHIMS.WebApi.Models;
using CHIMS.WebApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Controllers
{
    //this isfor patient type controller
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypesController : ControllerBase
    {
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public ServiceTypesController(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<ServiceType>>> GetServiceTypes()
        {
            return await _serviceTypeRepository.GetServiceTypesAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceType>> GetServiceType(int id)
        {
            var serviceType = await _serviceTypeRepository.GetServiceTypeAsync(id);

            if (serviceType == null)
            {
                return NotFound();
            }

            return serviceType;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceType([FromRoute] int id, [FromBody] ServiceType serviceType)
        {
            await _serviceTypeRepository.PutServiceTypeAsync(id, serviceType);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostServiceType([FromBody] ServiceType serviceType)
        {
            var id = await _serviceTypeRepository.PostServiceTypeAsync(serviceType);

            return CreatedAtAction(nameof(GetServiceType), new { id, controller = "ServiceTypes" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceType(int id)
        {
            await _serviceTypeRepository.DeleteServiceTypeAsync(id);
            return Ok();

        }
    }
}

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
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationsController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        // GET: api/{controller}
        [HttpGet]
        public async Task<ActionResult<List<Organization>>> GetOrganizations()
        {
            return await _organizationRepository.GetOrganizationsAsync();
        }

        // GET: api/{controller}/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(int id)
        {
            var organization = await _organizationRepository.GetOrganizationAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            return organization;
        }

        // PUT: api/{controller}/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization([FromRoute] int id, [FromBody] Organization organization)
        {
            await _organizationRepository.PutOrganizationAsync(id, organization);
            return Ok();
        }

        // POST: api/{controller}
        [HttpPost("")]
        public async Task<ActionResult> PostOrganization([FromBody] Organization organization)
        {
            var id = await _organizationRepository.PostOrganizationAsync(organization);

            return CreatedAtAction(nameof(GetOrganization), new { id, controller = "Organizations" }, id);
        }

        // DELETE: api/{controller}/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(int id)
        {
            await _organizationRepository.DeleteOrganizationAsync(id);
            return Ok();

        }
    }
}

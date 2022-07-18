using CHIMS.WebApi.Data;
using CHIMS.WebApi.Models;
using CHIMS.WebApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;

        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteOrganizationAsync(int id)
        {
            var organization = new Organization() { Id = id };

            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Organization>> GetOrganizationAsync(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);

            return organization;
        }

        public async Task<ActionResult<List<Organization>>> GetOrganizationsAsync()
        {
            var organizations = await _context.Organizations.ToListAsync();
            return organizations;
        }

        public async Task<int> PostOrganizationAsync(Organization organization)
        {
            if (organization != null)
            {
                _context.Add(organization);
                await _context.SaveChangesAsync();

                return organization.Id;
            }

            return 0;
        }

        public async Task PutOrganizationAsync(int id, Organization organization)
        {
            var getOrganization = new Organization()
            {
                Id = id,
                Name = organization.Name,
                AgreementLetter = organization.AgreementLetter,
                AgreementStarted = organization.AgreementStarted,
                AgreementEnd = organization.AgreementEnd,
                WeredaId = organization.WeredaId,
                KebeleId = organization.KebeleId

            };

            _context.Organizations.Update(getOrganization);
            await _context.SaveChangesAsync();
        }
    }
}

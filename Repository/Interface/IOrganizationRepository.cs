using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IOrganizationRepository
    {
        Task<ActionResult<List<Organization>>> GetOrganizationsAsync();
        Task<ActionResult<Organization>> GetOrganizationAsync(int id);
        Task PutOrganizationAsync(int id, Organization organization);
        Task<int> PostOrganizationAsync(Organization organization);
        Task DeleteOrganizationAsync(int id);
    }
}

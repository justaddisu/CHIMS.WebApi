using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IServiceTypeRepository
    {
        Task<ActionResult<List<ServiceType>>> GetServiceTypesAsync();
        Task<ActionResult<ServiceType>> GetServiceTypeAsync(int id);
        Task PutServiceTypeAsync(int id, ServiceType serviceType);
        Task<int> PostServiceTypeAsync(ServiceType serviceType);
        Task DeleteServiceTypeAsync(int id);
    }
}

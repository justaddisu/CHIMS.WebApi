using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IServiceRepository
    {
        Task<ActionResult<List<Service>>> GetServicesAsync();
        Task<ActionResult<Service>> GetServiceAsync(int id);
        Task PutServiceAsync(int id, Service service);
        Task<int> PostServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}

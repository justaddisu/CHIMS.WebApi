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
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteServiceTypeAsync(int id)
        {
            var serviceType = new ServiceType() { Id = id };

            _context.ServiceTypes.Remove(serviceType);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<ServiceType>> GetServiceTypeAsync(int id)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);

            return serviceType;
        }

        public async Task<ActionResult<List<ServiceType>>> GetServiceTypesAsync()
        {
            var serviceTypes = await _context.ServiceTypes.ToListAsync();

            return serviceTypes;
        }

        public async Task<int> PostServiceTypeAsync(ServiceType serviceType)
        {
            if (serviceType != null)
            {
                _context.Add(serviceType);
                await _context.SaveChangesAsync();

                return serviceType.Id;
            }

            return 0;
        }

        public async Task PutServiceTypeAsync(int id, ServiceType serviceType)
        {
            var getServiceType = new ServiceType()
            {
                Id = id,
                Name = serviceType.Name,
            };

            _context.ServiceTypes.Update(getServiceType);
            await _context.SaveChangesAsync();
        }
    }
}

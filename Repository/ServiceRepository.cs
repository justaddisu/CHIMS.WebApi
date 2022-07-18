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
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteServiceAsync(int id)
        {
            var service = new Service() { Id = id };

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

        }

        public async Task<ActionResult<Service>> GetServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);

            return service;
        }

        public async Task<ActionResult<List<Service>>> GetServicesAsync()
        {
            var services = await _context.Services.ToListAsync();

            return services;
        }

        public async Task<int> PostServiceAsync(Service service)
        {
            if (service != null)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();

                return service.Id;
            }

            return 0;
        }

        public async Task PutServiceAsync(int id, Service service)
        {
            var getService = new Service()
            {
                Id = id,
                Name = service.Name,
                Price = service.Price,
                Description = service.Description,
                Status = service.Status,
                CategoryId = service.CategoryId
            };

            _context.Services.Update(getService);
            await _context.SaveChangesAsync();
        }
    }
}

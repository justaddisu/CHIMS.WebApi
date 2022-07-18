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
    public class ServiceExpenseRepository : IServiceExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteServiceExpenseAsync(int id)
        {
            var serviceExpense = new ServiceExpense() { Id = id };

            _context.ServiceExpenses.Remove(serviceExpense);
            await _context.SaveChangesAsync();

        }

        public async Task<ActionResult<ServiceExpense>> GetServiceExpenseAsync(int id)
        {
            var serviceExpense = await _context.ServiceExpenses.FindAsync(id);

            return serviceExpense;
        }

        public async Task<ActionResult<List<ServiceExpense>>> GetServiceExpensesAsync()
        {
            var serviceExpenses = await _context.ServiceExpenses.ToListAsync();

            return serviceExpenses;
        }

        public async Task<int> PostServiceExpenseAsync(ServiceExpense serviceExpense)
        {
            if (serviceExpense != null)
            {
                _context.Add(serviceExpense);
                await _context.SaveChangesAsync();

                return serviceExpense.Id;
            }

            return 0;
        }

        public async Task PutServiceExpenseAsync(int id, ServiceExpense serviceExpense)
        {
            var getServiceExpense = new ServiceExpense()
            {
                Id = id,
                PatientId = serviceExpense.PatientId,
                CategoryId = serviceExpense.CategoryId,
                ServiceId = serviceExpense.ServiceId,
                Price = serviceExpense.Price,
                IsExempted = serviceExpense.IsExempted
            };

            _context.ServiceExpenses.Update(getServiceExpense);
            await _context.SaveChangesAsync();
        }
    }
}

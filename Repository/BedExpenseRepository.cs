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
    public class BedExpenseRepository: IBedExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public BedExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteBedExpenseAsync(int id)
        {
            var bedExpense = new BedExpense() { Id = id };

            _context.BedExpenses.Remove(bedExpense);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<BedExpense>> GetBedExpenseAsync(int id)
        {
            var bedExpense = await _context.BedExpenses.FindAsync(id);

            return bedExpense;
        }

        public async Task<ActionResult<List<BedExpense>>> GetBedExpensesAsync()
        {
            var bedExpenses = await _context.BedExpenses.ToListAsync();

            return bedExpenses;
        }

        public async Task<int> PostBedExpenseAsync(BedExpense bedExpense)
        {
            if (bedExpense != null)
            {
                _context.Add(bedExpense);
                await _context.SaveChangesAsync();

                return bedExpense.Id;
            }

            return 0;
        }

        public async Task PutBedExpenseAsync(int id, BedExpense bedExpense)
        {
            var getBedExpense = new BedExpense()
            {
                Id = id,
                PatientId = bedExpense.PatientId,
                DepartmentId = bedExpense.DepartmentId,
                ConditionId = bedExpense.ConditionId,
                BedId = bedExpense.BedId,
                DateOfAdmission = bedExpense.DateOfAdmission,
                DateOfDischarge = bedExpense.DateOfDischarge,
                Price = bedExpense.Price,
                ServiceCharge = bedExpense.ServiceCharge,
                IsExempted = bedExpense.IsExempted

            };

            _context.BedExpenses.Update(getBedExpense);
            await _context.SaveChangesAsync();
        }
    }
}



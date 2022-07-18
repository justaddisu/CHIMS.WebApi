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
    public class DrugExpenseRepository : IDrugExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public DrugExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteDrugExpenseAsync(int id)
        {
            var drugExpense = new DrugExpense() { Id = id };

            _context.DrugExpenses.Remove(drugExpense);
            await _context.SaveChangesAsync();

        }

        public async Task<ActionResult<DrugExpense>> GetDrugExpenseAsync(int id)
        {
            var drugExpense = await _context.DrugExpenses.FindAsync(id);

            return drugExpense;
        }

        public async Task<ActionResult<List<DrugExpense>>> GetDrugExpensesAsync()
        {
            var drugExpenses = await _context.DrugExpenses.ToListAsync();

            return drugExpenses;
        }

        public async Task<int> PostDrugExpenseAsync(DrugExpense drugExpense)
        {
            if (drugExpense != null)
            {
                _context.Add(drugExpense);
                await _context.SaveChangesAsync();

                return drugExpense.Id;
            }

            return 0;
        }

        public async Task PutDrugExpenseAsync(int id, DrugExpense drugExpense)
        {
            var getDrugExpense = new DrugExpense()
            {
                Id = id,
                PatientId = drugExpense.PatientId,
                DrugId = drugExpense.DrugId,
                Price = drugExpense.Price,
                PrescriberFullName = drugExpense.PrescriberFullName,
                PrescriberRegistration = drugExpense.PrescriberRegistration,
                PrescriptionDate = drugExpense.PrescriptionDate,
                EvaluaterFullName = drugExpense.EvaluaterFullName,
                EvaluaterRegistration = drugExpense.EvaluaterRegistration,
                EvaluationDate = drugExpense.EvaluationDate,
                IsExempted = drugExpense.IsExempted,
            };

            _context.DrugExpenses.Update(getDrugExpense);
            await _context.SaveChangesAsync();
        }
    }
}

using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IDrugExpenseRepository
    {
        Task<ActionResult<List<DrugExpense>>> GetDrugExpensesAsync();
        Task<ActionResult<DrugExpense>> GetDrugExpenseAsync(int id);
        Task PutDrugExpenseAsync(int id, DrugExpense drugExpense);
        Task<int> PostDrugExpenseAsync(DrugExpense drugExpense);
        Task DeleteDrugExpenseAsync(int id);
    }
}

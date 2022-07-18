using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IBedExpenseRepository
    {
        Task<ActionResult<List<BedExpense>>> GetBedExpensesAsync();
        Task<ActionResult<BedExpense>> GetBedExpenseAsync(int id);
        Task PutBedExpenseAsync(int id, BedExpense bedExpense);
        Task<int> PostBedExpenseAsync(BedExpense bedExpense);
        Task DeleteBedExpenseAsync(int id);
    }
}

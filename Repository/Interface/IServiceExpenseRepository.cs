using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IServiceExpenseRepository
    {
        Task<ActionResult<List<ServiceExpense>>> GetServiceExpensesAsync();
        Task<ActionResult<ServiceExpense>> GetServiceExpenseAsync(int id);
        Task PutServiceExpenseAsync(int id, ServiceExpense serviceExpense);
        Task<int> PostServiceExpenseAsync(ServiceExpense serviceExpense);
        Task DeleteServiceExpenseAsync(int id);
    }
}

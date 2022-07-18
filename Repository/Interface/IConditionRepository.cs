using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IConditionRepository
    {
        Task<ActionResult<List<Condition>>> GetConditionsAsync();
        Task<ActionResult<Condition>> GetConditionAsync(int id);
        Task PutConditionAsync(int id, Condition condition);
        Task<int> PostConditionAsync(Condition condition);
        Task DeleteConditionAsync(int id);
    }
}

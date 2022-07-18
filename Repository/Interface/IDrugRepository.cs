using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IDrugRepository
    {
        Task<ActionResult<List<Drug>>> GetDrugsAsync();
        Task<ActionResult<Drug>> GetDrugAsync(int id);
        Task PutDrugAsync(int id, Drug drug);
        Task<int> PostDrugAsync(Drug drug);
        Task DeleteDrugAsync(int id);
    }
}

using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IBedRepository
    {
        Task<ActionResult<List<Bed>>> GetBedsAsync();
        Task<ActionResult<Bed>> GetBedAsync(int id);
        Task PutBedAsync(int id, Bed bed);
        Task<int> PostBedAsync(Bed bed);
        Task DeleteBedAsync(int id);
    }
}

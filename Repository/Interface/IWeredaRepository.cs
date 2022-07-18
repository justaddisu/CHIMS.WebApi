using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IWeredaRepository
    {
        Task<ActionResult<List<Wereda>>> GetWeredasAsync();
        Task<ActionResult<Wereda>> GetWeredaAsync(int id);
        Task PutWeredaAsync(int id, Wereda wereda);
        Task<int> PostWeredaAsync(Wereda wereda);
        Task DeleteWeredaAsync(int id);
    }
}

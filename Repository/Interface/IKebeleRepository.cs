using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IKebeleRepository
    {
        Task<ActionResult<List<Kebele>>> GetKebelesAsync();
        Task<ActionResult<Kebele>> GetKebeleAsync(int id);
        Task PutKebeleAsync(int id, Kebele kebele);
        Task<int> PostKebeleAsync(Kebele kebele);
        Task DeleteKebeleAsync(int id);

    }
}

using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IWardRepository
    {
        Task<ActionResult<List<Ward>>> GetWardsAsync();
        Task<ActionResult<Ward>> GetWardAsync(int id);
        Task PutWardAsync(int id, Ward ward);
        Task<int> PostWardAsync(Ward ward);
        Task DeleteWardAsync(int id);
    }
}

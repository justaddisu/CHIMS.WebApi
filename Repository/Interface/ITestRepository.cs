using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface ITestRepository
    {
        Task<ActionResult<List<Test>>> GetTestsAsync();
        Task<ActionResult<Test>> GetTestAsync(int id);
        Task PutTestAsync(int id, Test test);
        Task<int> PostTestAsync(Test test);
        Task DeleteTestAsync(int id);
    }
}

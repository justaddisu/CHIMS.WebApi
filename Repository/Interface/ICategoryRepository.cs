using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<ActionResult<List<Category>>> GetCategorysAsync();
        Task<ActionResult<Category>> GetCategoryAsync(int id);
        Task PutCategoryAsync(int id, Category category);
        Task<int> PostCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}

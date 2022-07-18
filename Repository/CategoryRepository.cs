using CHIMS.WebApi.Data;
using CHIMS.WebApi.Models;
using CHIMS.WebApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = new Category() { Id = id };

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Category>> GetCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            return category;
        }

        public async Task<ActionResult<List<Category>>> GetCategorysAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<int> PostCategoryAsync(Category category)
        {
            if (category != null)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();

                return category.Id;
            }

            return 0;
        }

        public async Task PutCategoryAsync(int id, Category category)
        {
            var getCategory = new Category()
            {
                Id = id,
                Name = category.Name,
                Description = category.Description
            };

            _context.Categories.Update(getCategory);
            await _context.SaveChangesAsync();
        }
    }
}

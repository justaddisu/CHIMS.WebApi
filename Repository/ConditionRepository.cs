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
    public class ConditionRepository: IConditionRepository
    {
        private readonly ApplicationDbContext _context;

        public ConditionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteConditionAsync(int id)
        {
            var condition = new Condition() { Id = id };

            _context.Conditions.Remove(condition);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Condition>> GetConditionAsync(int id)
        {
            var condition = await _context.Conditions.FindAsync(id);

            return condition;
        }

        public async Task<ActionResult<List<Condition>>> GetConditionsAsync()
        {
            var conditions = await _context.Conditions.ToListAsync();

            return conditions;
        }

        public async Task<int> PostConditionAsync(Condition condition)
        {
            if (condition != null)
            {
                _context.Add(condition);
                await _context.SaveChangesAsync();

                return condition.Id;
            }

            return 0;
        }

        public async Task PutConditionAsync(int id, Condition condition)
        {
            var getCondition = new Condition()
            {
                Id = id,
                Name = condition.Name,
                Description = condition.Description
            };

            _context.Conditions.Update(getCondition);
            await _context.SaveChangesAsync();
        }
    }
}

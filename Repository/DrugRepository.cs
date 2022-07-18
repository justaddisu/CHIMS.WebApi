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
    public class DrugRepository : IDrugRepository
    {
        private readonly ApplicationDbContext _context;

        public DrugRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteDrugAsync(int id)
        {
            var drug = new Drug() { Id = id };

            _context.Drugs.Remove(drug);
            await _context.SaveChangesAsync();

        }

        public async Task<ActionResult<Drug>> GetDrugAsync(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);

            return drug;
        }

        public async Task<ActionResult<List<Drug>>> GetDrugsAsync()
        {
            var drugs = await _context.Drugs.ToListAsync();

            return drugs;
        }

        public async Task<int> PostDrugAsync(Drug drug)
        {
            if (drug != null)
            {
                _context.Add(drug);
                await _context.SaveChangesAsync();

                return drug.Id;
            }

            return 0;
        }

        public async Task PutDrugAsync(int id, Drug drug)
        {
            var getDrug = new Drug()
            {
                Id = id,
                Name = drug.Name,
                Price = drug.Price,
                Repitation = drug.Repitation,
                Description = drug.Description,
                Status = drug.Status
            };

            _context.Drugs.Update(getDrug);
            await _context.SaveChangesAsync();
        }
    }
}

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
    public class BedRepository: IBedRepository
    {
        private readonly ApplicationDbContext _context;

        public BedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteBedAsync(int id)
        {
            var bed = new Bed() { Id = id };

            _context.Beds.Remove(bed);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Bed>> GetBedAsync(int id)
        {
            var bed = await _context.Beds.FindAsync(id);

            return bed;
        }

        public async Task<ActionResult<List<Bed>>> GetBedsAsync()
        {
            var beds = await _context.Beds.ToListAsync();

            return beds;
        }

        public async Task<int> PostBedAsync(Bed bed)
        {
            if (bed != null)
            {
                _context.Add(bed);
                await _context.SaveChangesAsync();

                return bed.Id;
            }

            return 0;
        }

        public async Task PutBedAsync(int id, Bed bed)
        {
            var getBed = new Bed()
            {
                Id = id,
                Level = bed.Level,
                Description = bed.Description,
                Price = bed.Price,
                Status = bed.Status

            };

            _context.Beds.Update(getBed);
            await _context.SaveChangesAsync();
        }
    }
}

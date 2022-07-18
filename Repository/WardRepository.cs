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
    public class WardRepository : IWardRepository
    {
        private readonly ApplicationDbContext _context;

        public WardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteWardAsync(int id)
        {
            var ward = new Ward() { Id = id };

            _context.Wards.Remove(ward);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Ward>> GetWardAsync(int id)
        {
            var ward = await _context.Wards.FindAsync(id);

            return ward;
        }

        public async Task<ActionResult<List<Ward>>> GetWardsAsync()
        {
            var wards = await _context.Wards.ToListAsync();

            return wards;
        }

        public async Task<int> PostWardAsync(Ward ward)
        {
            if (ward != null)
            {
                _context.Add(ward);
                await _context.SaveChangesAsync();

                return ward.Id;
            }

            return 0;
        }

        public async Task PutWardAsync(int id, Ward ward)
        {
            var getWard = new Ward()
            {
                Id = id,
                Name = ward.Name,
                Description = ward.Description,
                Status = ward.Status,
                DepartmentId = ward.DepartmentId

            };

            _context.Wards.Update(getWard);
            await _context.SaveChangesAsync();
        }
    }
}

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
    public class KebeleRepository : IKebeleRepository
    {
        private readonly ApplicationDbContext _context;

        public KebeleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteKebeleAsync(int id)
        {
            var kebele = new Kebele() { Id = id };

            _context.Kebeles.Remove(kebele);
            await _context.SaveChangesAsync();

        }

        public async Task<ActionResult<Kebele>> GetKebeleAsync(int id)
        {
            var kebele = await _context.Kebeles.FindAsync(id);

            return kebele;
        }

        public async Task<ActionResult<List<Kebele>>> GetKebelesAsync()
        {
            var kebeles = await _context.Kebeles.ToListAsync();

            return kebeles;
        }

        public async Task<int> PostKebeleAsync(Kebele kebele)
        {
            if(kebele != null)
            {
                _context.Add(kebele);
                await _context.SaveChangesAsync();

                return kebele.Id;
            }

            return 0;
        }

        public async Task PutKebeleAsync(int id, Kebele kebele)
        {
            var getKebele = new Kebele()
            {
                Id = id,
                Name = kebele.Name,
                WeredaId = kebele.WeredaId
            };

            _context.Kebeles.Update(getKebele);
            await _context.SaveChangesAsync();
        }
    }
}

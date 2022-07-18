using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CHIMS.WebApi.Models;
using CHIMS.WebApi.Repository.Interface;
using CHIMS.WebApi.Data;

namespace CHIMS.WebApi.Repository
{
    public class WeredaRepository : IWeredaRepository
    {
        private readonly ApplicationDbContext _context;

        public WeredaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteWeredaAsync(int id)
        {
            var wereda = new Wereda() { Id = id };

            _context.Weredas.Remove(wereda);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Wereda>> GetWeredaAsync(int id)
        {
            var wereda = await _context.Weredas.FindAsync(id);
            return wereda;

        }

        public async Task<ActionResult<List<Wereda>>> GetWeredasAsync()
        {
            var weredas = await _context.Weredas.ToListAsync();
            return weredas;
        }

        public async Task<int> PostWeredaAsync(Wereda wereda)
        {
            if (wereda != null)
            {
                _context.Weredas.Add(wereda);
                await _context.SaveChangesAsync();

                return wereda.Id;
            }

            return 0;
        }

        public async Task PutWeredaAsync(int id, Wereda wereda)
        {
            var getKebele = new Wereda()
            {
                Id = id,
                Name = wereda.Name,
            };

            _context.Weredas.Update(getKebele);
            await _context.SaveChangesAsync();

        }

     
    }
}

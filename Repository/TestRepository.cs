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
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _context;

        public TestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteTestAsync(int id)
        {
            var test = new Test() { Id = id };

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
        }

        // get test by id
        public async Task<ActionResult<Test>> GetTestAsync(int id)
        {
            var test = await _context.Tests.FindAsync(id);

            return test;
        }

        // get all tests 
        public async Task<ActionResult<List<Test>>> GetTestsAsync()
        {
            var tests = await _context.Tests.ToListAsync();

            return tests;
        }

        //create new test
        public async Task<int> PostTestAsync(Test test)
        {

            if (test != null)
            {
                _context.Tests.Add(test);
                await _context.SaveChangesAsync();

                return test.Id;
            }

            return 0;
        }

        public async Task PutTestAsync(int id, Test test)
        {
            var getTest = new Test()
            {
                Id = id,
                Name = test.Name,
                Description = test.Description
            };

            _context.Tests.Update(getTest);
            await _context.SaveChangesAsync();

        }

       
    }
}

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
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = new Department() { Id = id };

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Department>> GetDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            return department;
        }

        public async Task<ActionResult<List<Department>>> GetDepartmentsAsync()
        {
            var departments = await _context.Departments.ToListAsync();

            return departments;
        }

        public async Task<int> PostDepartmentAsync(Department department)
        {
            if (department != null)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();

                return department.Id;
            }

            return 0;
        }

        public async Task PutDepartmentAsync(int id, Department department)
        {
            var getDepartment = new Department()
            {
                Id = id,
                Name = department.Name,
                Description = department.Description,
                Status = department.Status
            };

            _context.Departments.Update(getDepartment);
            await _context.SaveChangesAsync();
        }
    }
}


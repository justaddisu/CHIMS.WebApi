using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IDepartmentRepository
    {
        Task<ActionResult<List<Department>>> GetDepartmentsAsync();
        Task<ActionResult<Department>> GetDepartmentAsync(int id);
        Task PutDepartmentAsync(int id, Department department);
        Task<int> PostDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
    }
}

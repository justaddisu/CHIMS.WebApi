using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Repository.Interface
{
    public interface IPatientRepository
    {
        Task<ActionResult<List<Patient>>> GetPatientsAsync();
        Task<ActionResult<Patient>> GetPatientAsync(int id);
        Task PutPatientAsync(int id, Patient patient);
        Task<int> PostPatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
    }
}

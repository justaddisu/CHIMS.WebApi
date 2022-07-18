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
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = new Patient() { Id = id };

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Patient>> GetPatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            return patient;
        }

        public async Task<ActionResult<List<Patient>>> GetPatientsAsync()
        {
            var patients = await _context.Patients.ToListAsync();
            return patients;
        }

        public async Task<int> PostPatientAsync(Patient patient)
        {
            if (patient != null)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();

                return patient.Id;
            }

            return 0;
        }

        public async Task PutPatientAsync(int id, Patient patient)
        {
            var getPatient = new Patient()
            {
                Id = id,
                FirstName = patient.FirstName,
                MiddleName = patient.MiddleName,
                LastName = patient.LastName,
                Gender = patient.Gender,
                DateOfBirth = patient.DateOfBirth,
                Photo = patient.Photo,
                IdNumber = patient.IdNumber,
                MRM = patient.Photo,
                WeredaId = patient.WeredaId,
                OrganizationId = patient.OrganizationId,
                KebeleId = patient.KebeleId,
                ServiceTypeId = patient.ServiceTypeId,
                IsOrganization = patient.IsOrganization

            };

            _context.Patients.Update(getPatient);
            await _context.SaveChangesAsync();
        }
    }
}

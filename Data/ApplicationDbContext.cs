using CHIMS.WebApi.Helpers;
using CHIMS.WebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService currentUserService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            this.currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public DbSet<Wereda> Weredas { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Kebele> Kebeles { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<ServiceExpense> ServiceExpenses { get; set; }
        public DbSet<DrugExpense> DrugExpenses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<BedExpense> BedExpenses { get; set; }


        //for testing purpose
        public DbSet<Test> Tests { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessSave()
        {
            var currentTime = DateTime.Now;
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is Entity))
            {
                var entity = item.Entity as Entity;
                entity.CreateAt = currentTime;
                entity.CreateBy = currentUserService.GetCurrentUsername();
                entity.UpdateAt = currentTime;
                entity.UpdateBy = currentUserService.GetCurrentUsername();
            }

            foreach (var item in ChangeTracker.Entries()
              .Where(e => e.State == EntityState.Modified && e.Entity is Entity))
            {
                var entity = item.Entity as Entity;
                entity.UpdateAt = currentTime;
                entity.UpdateBy = currentUserService.GetCurrentUsername();
                item.Property(nameof(entity.CreateBy)).IsModified = false;
                item.Property(nameof(entity.CreateAt)).IsModified = false;
            }

        }


    }
}

using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank4Us.DataAccess.Core
{
    /// <summary>
    ///   Course Name: COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Ziwei Huang
    ///   Description: Example implementation of Entity Framework Core.
    ///                 http://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx  
    /// </summary>
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=tcp:bankforus-server.database.windows.net,1433;
                                        Database=Bank4Us_Assignment9;
                                        Persist Security Info=False;
                                        User ID=Bank4UsAdmin;
                                        Password=Sp@150725;MultipleActiveResultSets=False;
                                        Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
                                        ");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>()
            .Property(c => c.CreatedBy)
            .HasDefaultValue("admin");

            builder.Entity<Person>()
             .Property(c => c.UpdatedBy)
             .HasDefaultValue("admin");

            builder.Entity<Mortgage>()
             .Property(c => c.CreatedBy)
             .HasDefaultValue("admin");

            builder.Entity<Mortgage>()
             .Property(c => c.UpdatedBy)
             .HasDefaultValue("admin");

            builder.Entity<LoanOfficer>()
             .Property(c => c.CreatedBy)
             .HasDefaultValue("admin");

            builder.Entity<LoanOfficer>()
             .Property(c => c.UpdatedBy)
             .HasDefaultValue("admin");

            builder.Entity<MortgageApplicant>()
            .Property(c => c.CreatedBy)
            .HasDefaultValue("admin");

            builder.Entity<MortgageApplicant>()
             .Property(c => c.UpdatedBy)
             .HasDefaultValue("admin");

            builder.Entity<CreditReport>()
             .Property(c => c.CreatedBy)
             .HasDefaultValue("admin");

            builder.Entity<CreditReport>()
             .Property(c => c.UpdatedBy)
             .HasDefaultValue("admin");
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }
        #region Entities representing Database Objects
        public DbSet<Person> Persons { get; set; }
        public DbSet<Mortgage> Mortgages { get; set; }
        public DbSet<MortgageApplicant> MortgageApplicants { get; set; }
        public DbSet<CreditReport> CreditReports { get; set; }
        public DbSet<LoanOfficer> LoanOfficers { get; set; }

        #endregion
    }
}

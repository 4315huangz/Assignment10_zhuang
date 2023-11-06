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
                                        Database=Bank4Us_Assignment8;
                                        Persist Security Info=False;
                                        User ID=Bank4UsAdmin;
                                        Password=Sp@150725;MultipleActiveResultSets=False;
                                        Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
                                        ");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Mortgage> Mortgages { get; set;}
        public DbSet<MortgageApplicant> MortgageApplicants { get; set; }
        public DbSet<LoanOfficer> LoanOfficers { get; set;}
        public DbSet<CreditReport> CreditReports { get; set;}

    }
}

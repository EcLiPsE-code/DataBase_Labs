
using System.IO;
using Company.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Company.DATA
{
    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeFact> EmployeeFact { get; set; }
        public virtual DbSet<EmployeePlan> EmployeePlans { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ProgressEmployee> ProgressEmployees { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitsValuationFact> UnitsValuationFact { get; set; }
        public virtual DbSet<UnitsValuationPlan> UnitsValuationPlans { get; set; }
    }
}

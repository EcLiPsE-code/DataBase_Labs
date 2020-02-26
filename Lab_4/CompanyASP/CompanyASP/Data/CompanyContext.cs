using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace CompanyASP.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeFact> EmployeeFacts { get; set; }
        public DbSet<EmployeePlan> EmployeePlans { get; set; }
        public DbSet<ProgressEmployee> ProgressEmployees { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitValuationFact> UnitValuationFacts { get; set; }
        public DbSet<UnitValuationPlan> UnitValuationPlans { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyASP.Models;
using CompanyASP.Models.Indicators;
using Microsoft.EntityFrameworkCore;


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
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<DepartamentValuationFact> DepartamentValuationFacts { get; set; }
        public DbSet<DepartamentValuationPlan> DepartamentValuationPlans { get; set; }
        public DbSet<ListEmployeesMetrics> ListEmployeesMetrics { get; set; }
        public DbSet<ListDepartamentMetrics> ListDepartamentMetrics { get; set; }
    }
}

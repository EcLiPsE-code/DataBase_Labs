
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFConsole.Models
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            //string connectionString = config.GetConnectionString("SqliteConnection");
            string connectionString = config.GetConnectionString("SQLConnection");

            var options = optionsBuilder
                .UseSqlServer(connectionString)
                //.UseSqlite(connectionString)
                .Options;
        }
    }
}

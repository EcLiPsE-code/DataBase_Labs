using CompanyASP.Models.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
        public double Raiting { get; set; }

        public int DepartamentId { get; set; }
        public Departament Departament { get; set; } //навигационное свойство

        public ICollection<EmployeeFact> EmployeeFacts { get; set; }
        public ICollection<EmployeePlan> EmployeePlans { get; set; }
        public ICollection<ListEmployeesMetrics> ListEmployeesMetrics { get; set; }
        public ICollection<ProgressEmployee> ProgressEmployees { get; set; }
        public Employee()
        {
            ProgressEmployees = new List<ProgressEmployee>();
            EmployeeFacts = new List<EmployeeFact>();
            EmployeePlans = new List<EmployeePlan>();
            ListEmployeesMetrics = new List<ListEmployeesMetrics>();
        }
    }
}

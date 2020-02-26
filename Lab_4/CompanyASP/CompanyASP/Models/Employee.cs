using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public decimal Profit { get; set; }
        public int Age { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public ICollection<EmployeeFact> EmployeeFacts { get; set; }
        public ICollection<ProgressEmployee> ProgressEmployees { get; set; }
        public Employee()
        {
            EmployeeFacts = new List<EmployeeFact>();
            ProgressEmployees = new List<ProgressEmployee>();
        }
    }
}

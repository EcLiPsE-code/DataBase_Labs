using System;
using System.Collections.Generic;

namespace EFConsole.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeFact = new HashSet<EmployeeFact>();
            ProgressEmployees = new HashSet<ProgressEmployee>();
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public decimal? Solution { get; set; }
        public decimal? Profit { get; set; }
        public int? Age { get; set; }
        public int? UnitId { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual ICollection<EmployeeFact> EmployeeFact { get; set; }
        public virtual ICollection<ProgressEmployee> ProgressEmployees { get; set; }
    }
}

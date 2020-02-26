using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class EmployeeFact
    {
        public EmployeeFact()
        {
            EmployeePlans = new HashSet<EmployeePlan>();
        }

        public int EmployeeFactId { get; set; }
        public string FullName { get; set; }
        public int? Quarter { get; set; }
        public int? Year { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? ProfitYear { get; set; }
        public decimal? ProfitQuarter { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<EmployeePlan> EmployeePlans { get; set; }
    }
}

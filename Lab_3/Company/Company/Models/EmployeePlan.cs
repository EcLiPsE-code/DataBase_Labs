using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class EmployeePlan
    {
        public int EmployeePlanId { get; set; }
        public string FullName { get; set; }
        public int? Quarter { get; set; }
        public int? Year { get; set; }
        public int? EmployeeFactId { get; set; }
        public decimal? ProfitQuarter { get; set; }
        public decimal? ProfitYear { get; set; }

        public virtual EmployeeFact EmployeeFact { get; set; }
    }
}

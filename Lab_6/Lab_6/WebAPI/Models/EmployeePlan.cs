using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class EmployeePlan
    {
        public int Id { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public double PerfomanceQuarter { get; set; } //эффективность в процентах от 1 до 100
        public double PerfomanceYear { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}

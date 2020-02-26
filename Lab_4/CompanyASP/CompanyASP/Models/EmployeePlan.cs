using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class EmployeePlan
    {
        /// <summary>
        /// поля класса
        /// </summary>
        public int EmployeePlanID { get; set; }
        public string FullName { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public decimal ProfitQuarter { get; set; }
        public decimal ProfitYear { get; set; }

        /// <summary>
        /// внешний ключ к таблице EmployeeFact
        /// </summary>
        public int EmployeeFactID { get; set; }
        public EmployeeFact EmployeeFact { get; set; }
    }
}

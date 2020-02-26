using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class EmployeeFact
    {
        /// <summary>
        /// поля класса
        /// </summary>
        public int EmployeeFactID { get; set; }
        public string FullName { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public decimal ProfitYear { get; set; }
        public decimal ProfitQuarter { get; set; }

        /// <summary>
        /// внешний ключ к таблице Employee
        /// </summary>
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }


        public ICollection<EmployeePlan> EmployeePlans { get; set; }
        public EmployeeFact()
        {
            EmployeePlans = new List<EmployeePlan>();
        }
    }
}

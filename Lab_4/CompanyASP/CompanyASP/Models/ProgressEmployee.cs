using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class ProgressEmployee
    {
        public int ProgressEmployeeID { get; set; }
        public string FullName { get; set; }
        public string Progress { get; set; }
        
        /// <summary>
        /// внешний ключ к таблице Employee
        /// </summary>
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}

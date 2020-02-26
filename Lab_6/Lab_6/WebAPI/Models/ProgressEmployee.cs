using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class ProgressEmployee
    {
        public int Id { get; set; }
        public string Progress { get; set; }
        
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}

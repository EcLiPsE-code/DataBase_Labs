using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class UnitValuationPlan
    {
        public int UnitValuationPlanID { get; set; }
        public string FullName { get; set; }
        public decimal Profit { get; set; }
        public decimal Salary { get; set; }

        /// <summary>
        /// внешний ключ к таблице UnitValuationFact
        /// </summary>
        public int UnitValuationFactID { get; set; }
        public UnitValuationFact UnitValuationFact { get; set; }

    }
}

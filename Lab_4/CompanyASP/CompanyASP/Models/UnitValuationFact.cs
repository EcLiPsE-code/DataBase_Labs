using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class UnitValuationFact
    {
        public int UnitValuationFactID { get; set; }
        public string FullName { get; set; }
        public decimal Profit { get; set; }
        public decimal Salary { get; set; }

        /// <summary>
        /// внешний ключ к таблице Unit
        /// </summary>
        public int UnitID { get; set; }
        public  Unit Unit { get; set; }

        public ICollection<UnitValuationPlan> UnitValuationPlans { get; set; }
        public UnitValuationFact()
        {
            UnitValuationPlans = new List<UnitValuationPlan>();
        }

    }
}

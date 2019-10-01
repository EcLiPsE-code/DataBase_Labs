using System;
using System.Collections.Generic;

namespace EFConsole.Models
{
    public partial class UnitsValuationFact
    {
        public UnitsValuationFact()
        {
            UnitsValuationPlans = new HashSet<UnitsValuationPlan>();
        }

        public int UnitValuationFactId { get; set; }
        public string FullName { get; set; }
        public decimal? Income { get; set; }
        public decimal? Cost { get; set; }
        public int? UnitId { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual ICollection<UnitsValuationPlan> UnitsValuationPlans { get; set; }
    }
}

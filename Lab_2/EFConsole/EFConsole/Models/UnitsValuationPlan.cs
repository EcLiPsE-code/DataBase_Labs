using System;
using System.Collections.Generic;

namespace EFConsole.Models
{
    public partial class UnitsValuationPlan
    {
        public int UnitValuationPlanId { get; set; }
        public string FullName { get; set; }
        public decimal? Income { get; set; }
        public decimal? Cost { get; set; }
        public int? UnitValuationFactId { get; set; }

        public virtual UnitsValuationFact UnitValuationFact { get; set; }
    }
}

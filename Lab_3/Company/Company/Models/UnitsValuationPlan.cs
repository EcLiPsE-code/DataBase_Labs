using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public partial class UnitsValuationPlan
    {
        [Key]
        public int UnitValuationPlanId { get; set; }
        public string FullName { get; set; }
        public decimal? Income { get; set; }
        public decimal? Cost { get; set; }
        public int? UnitValuationFactId { get; set; }

        public virtual UnitsValuationFact UnitValuationFact { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Company.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Employees = new HashSet<Employee>();
            UnitsValuationFact = new HashSet<UnitsValuationFact>();
        }

        public int UnitId { get; set; }
        public string FullName { get; set; }
        public int? CountEmployees { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<UnitsValuationFact> UnitsValuationFact { get; set; }
    }
}

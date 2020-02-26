using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CompanyASP.Models
{
    public class Unit
    {
        /// <summary>
        /// поля класса
        /// </summary>
        public int UnitID { get; set; }
        public string FullName { get; set; }
        public int CountEmployee { get; set; }


        public ICollection<UnitValuationFact> UnitValuationFacts { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public Unit()
        {
            UnitValuationFacts = new List<UnitValuationFact>();
            Employees = new List<Employee>();
        }
        
    }
}

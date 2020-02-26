using CompanyASP.Models.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class Departament
    {
        /// <summary>
        /// поля класса
        /// </summary>
        public int Id { get; set; }
        public string FullName { get; set; }
        public int CountEmployee { get; set; }

        public ICollection<Employee> Employees { get; set; } //навигационное свойство
        public ICollection<DepartamentValuationFact> DepartamentValuationFacts { get; set; }
        public ICollection<DepartamentValuationPlan> DepartamentValuationPlans { get; set; }
        public Departament()
        {
            Employees = new List<Employee>();
            DepartamentValuationFacts = new List<DepartamentValuationFact>();
            DepartamentValuationPlans = new List<DepartamentValuationPlan>();
        }
    }
}

using CompanyASP.Models.Indicators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models
{
    public class DepartamentValuationFact
    {
        public int Id { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public double PerfomanceYear { get; set; } //эффективность в процентах от 1 до 100
        public double PerfomanceQuarter { get; set; } //

        public int DepartamentId { get; set; }
        public Departament Departament { get; set; } //навигационное свойство
    }
}

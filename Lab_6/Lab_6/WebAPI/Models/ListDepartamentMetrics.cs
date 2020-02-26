 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Models.Indicators
{
    public class ListDepartamentMetrics
    {
        public int Id { get; set; }
        public int Quarter { get; set; }  
        public int Year { get; set; } 
        public int MarkYear { get; set; } 
        public int MarkQuarter { get; set; } 
        public int DepartamentId { get; set; }
        public Departament Departament { get; set; } 
    }
}

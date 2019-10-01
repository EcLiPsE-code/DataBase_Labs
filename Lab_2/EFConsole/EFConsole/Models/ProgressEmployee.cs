using System;
using System.Collections.Generic;

namespace EFConsole.Models
{
    public partial class ProgressEmployee
    {
        public int ProgressEmployeeId { get; set; }
        public string FullName { get; set; }
        public string Progress { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

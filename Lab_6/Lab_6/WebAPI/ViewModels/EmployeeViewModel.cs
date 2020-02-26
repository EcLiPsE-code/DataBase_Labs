using CompanyASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.ViewModel
{
    public class EmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; } //свойство для фильтрации

        [Display(Name = "Код сотрудника")]
        public int Id { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Зарплата")]
        public double Salary { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Display(Name ="Отдел")]
        public int DepartamentId { get; set; }
        [Display(Name ="Рейтинг")]
        public double Raiting { get; set; }
        public Departament Departament { get; set; }
    }
}

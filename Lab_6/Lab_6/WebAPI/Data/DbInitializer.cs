using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Data
{
    public class DbInitializer
    {
        private readonly RequestDelegate next;
        private static int employeeFactsCount = 100; //кол-во записей в таблице EmployeeFacts
        private static int employeePlansCount = 100; //в тадице EmployeePlans
        private static int employeesCount = 100; //в таблице Employee
        private static int progressEmployeeCount = 100; //в таблице ProgressEmployee
        private static int departamentCount = 100; //в таблице Departament
        private static int departamentValuationFactsCount = 100; //в таблице DepartamentValuationFacts
        private static int departamentValuationPlansCount = 100; //в таблице DepartamentValuationPlans
        private static int listDepartamentMetrics = 100;//в таблице ListDepartamentMetrics
        private static int listEmployeesMetrics = 100;//в таблице ListEmployeesMetrics
        private static Random randObj;

        public DbInitializer(RequestDelegate next)
        {
            this.next = next;
        }
        public static void Initialize(CompanyContext db)
        {
            InitializeDepartaments(db);
            InitializeEmployee(db);
            InitializeDepartamentValuationFacts(db);
            InitializeDepartamentValuationPlans(db);
            InitializeListDepartamentMetrics(db);
            InitializeEmployeeFacts(db);
            InitializeEmployeePlans(db);
            InitializeListEmployeesMetrics(db);
            InitializeProgressEmployee(db);
        }
        private static void InitializeDepartaments(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.Departaments.Any())
            {
                return;
            }
            else
            {
                string departamentName;
                int countEmployee;

                Random randObj = new Random(1);

                string[] departament_voc = { "администрация", "отдел кадров", "отдел маркетинга", "отдел продаж", "отдел финансов", "отдел логистики", "отдел IT", "отдел закупок", "отдел исследования и развития" };
                int count_departament_voc = departament_voc.GetLength(0);
                for (int departamentId = 1; departamentId <= departamentCount; departamentId++)
                {
                    departamentName = departament_voc[randObj.Next(count_departament_voc)];
                    countEmployee = (int)randObj.Next(50, 150);
                    db.Departaments.Add(new Models.Departament { FullName = departamentName, CountEmployee = countEmployee });
                }
                db.SaveChanges();
            }
        }
        private static void InitializeDepartamentValuationFacts(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.DepartamentValuationFacts.Any())
            {
                return;
            }
            else
            {
                int quarter; 
                int year;
                double perfomanceQuarter; //эффективность
                double perfomanceYear;
                int departamentId;

                randObj = new Random(1);

                for (var departamentValuationFactId = 1; departamentValuationFactId <= departamentValuationFactsCount; departamentValuationFactId++)
                {
                    quarter = (int)randObj.Next(1, 3);
                    perfomanceQuarter = (double)randObj.Next(10, 100);
                    perfomanceYear = (double)randObj.Next(10, 100);
                    departamentId = (int)randObj.Next(1, 101);
                    year = (int)randObj.Next(1970, 2020);
                    db.DepartamentValuationFacts.Add(new Models.DepartamentValuationFact { Quarter = quarter, Year = year, PerfomanceYear = perfomanceYear, PerfomanceQuarter = perfomanceQuarter, DepartamentId = departamentId });
                }
                db.SaveChanges();
            }
        }
        private static void InitializeDepartamentValuationPlans(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.DepartamentValuationPlans.Any())
            {
                return;
            }
            else
            {
                int quarter;
                int year;
                double perfomanceQuarter; //эффективность
                double perfomanceYear;
                int departamentId;

                randObj = new Random(1);

                for (var departamentValuationPlanId = 1; departamentValuationPlanId <= departamentValuationPlansCount; departamentValuationPlanId++)
                {
                    quarter = (int)randObj.Next(1, 3);
                    perfomanceQuarter = (double)randObj.Next(10, 100);
                    perfomanceYear = (double)randObj.Next(10, 100);
                    departamentId = (int)randObj.Next(1, 101);
                    year = (int)randObj.Next(1970, 2020);
                    db.DepartamentValuationPlans.Add(new Models.DepartamentValuationPlan { Quarter = quarter, Year = year, PerfomanceYear = perfomanceYear, PerfomanceQuarter = perfomanceQuarter, DepartamentId = departamentId });
                }
                db.SaveChanges();
            }
        }
        private static void InitializeEmployeeFacts(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.EmployeeFacts.Any())
            {
                return;
            }
            else
            {
                int quarter;
                int year;
                double perfomanceQuarter; //эффективность
                double perfomanceYear;
                int employeeId;

                randObj = new Random(1);

                for (int employeeFactId = 1; employeeFactId <= employeeFactsCount; employeeFactId++)
                {
                    quarter = (int)randObj.Next(1, 3);
                    year = (int)randObj.Next(1970, 2020);
                    perfomanceQuarter = (double)randObj.Next(10, 100);
                    perfomanceYear = (double)randObj.Next(10, 100);
                    employeeId = (int)randObj.Next(1, 101);
                    db.EmployeeFacts.Add(new Models.EmployeeFact { Quarter = quarter, Year = year, PerfomanceQuarter = perfomanceQuarter, PerfomanceYear = perfomanceYear, EmployeeId = employeeId});
                }
                db.SaveChanges();
            }
        }
        private static void InitializeEmployeePlans(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.EmployeePlans.Any())
            {
                return;
            }
            else
            {
                int quarter;
                int year;
                double perfomanceQuarter; //эффективность
                double perfomanceYear;
                int employeePlanId;

                randObj = new Random(1);

                for (int count = 1; count <= employeePlansCount; count++)
                {
                    quarter = (int)randObj.Next(1, 3);
                    year = (int)randObj.Next(1970, 2020);
                    perfomanceQuarter = (double)randObj.Next(10, 100);
                    perfomanceYear = (double)randObj.Next(10, 100);
                    employeePlanId = (int)randObj.Next(1, 101);
                    db.EmployeePlans.Add(new Models.EmployeePlan { Quarter = quarter, Year = year, PerfomanceQuarter = perfomanceQuarter, PerfomanceYear = perfomanceYear, EmployeeId = employeePlanId });
                }
                db.SaveChanges();
            }
        }
        private static void InitializeEmployee(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.Employees.Any())
            {
                return;
            }
            else
            {
                string fullName;
                double salary;
                int departamentId;
                int age;
                double raiting;

                randObj = new Random(1);
                string[] employee_voc = { "Солодков М.А", "Трофимов Е.В", "Мартинович И.А", "Назаренко И.А", "Грамович А.В", "Брусенцова Ю.В", "Пархоменко П.И", "Колос В.В" };
                int count_employee_voc = employee_voc.GetLength(0);
                for (int count = 1; count <= employeesCount; count++)
                {
                    fullName = employee_voc[randObj.Next(count_employee_voc)] + "_" + count.ToString();
                    salary = (double)randObj.Next(1000, 2000);
                    age = (int)randObj.Next(20, 55);
                    departamentId = (int)randObj.Next(1, 101);
                    raiting = randObj.Next(1, 10);
                    db.Employees.Add(new Models.Employee { FullName = fullName, Salary = salary, Age = age, DepartamentId = departamentId, Raiting = raiting });
                }
                db.SaveChanges();
            }
        }
        private static void InitializeProgressEmployee(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.ProgressEmployees.Any())
            {
                return;
            }
            else
            {
                string progress;
                int employeeId;

                randObj = new Random(1);

                string[] progress_voc = { "выполнил работу вовремя", "просрочил дедлайн", "разлил кофе на клавиатуру", "повесился", "получил прибавку к заралпте", "повысился в должности" };

                int count_progress_voc = progress_voc.GetLength(0);
                for (int progressEmployeeId = 1; progressEmployeeId <= progressEmployeeCount; progressEmployeeId++)
                {
                    progress = progress_voc[randObj.Next(count_progress_voc)];
                    employeeId = (int)randObj.Next(1, 101);
                    db.ProgressEmployees.Add(new Models.ProgressEmployee {Progress = progress, EmployeeID = employeeId });
                }
                db.SaveChanges();
            }
        }
        private static void InitializeListEmployeesMetrics(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.ListEmployeesMetrics.Any())
            {
                return;
            }
            else
            {
                int quarter;
                int year;
                int markYear;
                int markQuarter;
                int employeeId;

                randObj = new Random(1);

                for (int count = 1; count <= listEmployeesMetrics; count++)
                {
                    quarter = (int)randObj.Next(1, 3);
                    year = (int)randObj.Next(1970, 2020);
                    markQuarter = (int)randObj.Next(1, 10);
                    markYear = (int)randObj.Next(1, 10);
                    employeeId = (int)randObj.Next(1, 101);
                    db.ListEmployeesMetrics.Add(new Models.Indicators.ListEmployeesMetrics { Quarter = quarter, Year = year, MarkQuarter = markQuarter, MarkYear = markYear, EmployeeId = employeeId });
                }
            }
        }
        private static void InitializeListDepartamentMetrics(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.ListEmployeesMetrics.Any())
            {
                return;
            }
            else
            {
                int quarter;
                int year;
                int markYear;
                int markQuarter;
                int departamentId;

                randObj = new Random(1);

                for (int count = 1; count <= listDepartamentMetrics; count++)
                {
                    quarter = (int)randObj.Next(1, 3);
                    year = (int)randObj.Next(1970, 2020);
                    markQuarter = (int)randObj.Next(1, 10);
                    markYear = (int)randObj.Next(1, 10);
                    departamentId = (int)randObj.Next(1, 101);
                    db.ListDepartamentMetrics.Add(new Models.Indicators.ListDepartamentMetrics { Quarter = quarter, Year = year, MarkQuarter = markQuarter, MarkYear = markYear, DepartamentId = departamentId });
                }
            }
        }
    }
}

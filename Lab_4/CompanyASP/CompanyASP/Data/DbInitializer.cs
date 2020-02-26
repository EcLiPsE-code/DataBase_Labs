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
        private static int employeeFactsCount = 100;
        private static int employeePlansCount = 100;
        private static int employeesCount = 100;
        private static int progressEmployeeCount = 100;
        private static int unitCount = 100;
        private static int unitValuationFactsCount = 100;
        private static int unitValuationPlansCount = 100;
        private static Random randObj;

        public DbInitializer(RequestDelegate next)
        {
            this.next = next;
        }
        public static void Initialize(CompanyContext db)
        {
            InitializeUnits(db);
            InitializeEmployee(db);
            InitializeUnitValuationFacts(db);
            InitializeUnitValuationPlans(db);
            InitializeEmployeeFacts(db);
            InitializeEmployeePlans(db);
            InitializeProgressEmployee(db);
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
                string fullName;
                int quarter;
                int year;
                decimal profitYear;
                decimal profitQuarter;
                int employeeId;

                randObj = new Random(1);

                string[] employeeFacts_voc = { "Солодков М.А", "Трофимов Е.В", "Мартинович И.А", "Назаренко И.А", "Грамович А.В", "Брусенцова Ю.В", "Пархоменко П.И", "Колос В.В" };
                int count_employeeFacts_voc = employeeFacts_voc.GetLength(0);
                for (int employeeFactId = 1; employeeFactId < employeeFactsCount; employeeFactId++)
                {
                    fullName = employeeFacts_voc[randObj.Next(count_employeeFacts_voc)] + employeeFactId.ToString();
                    quarter = (int)randObj.Next(30000, 50000);
                    year = (int)randObj.Next(60000, 100000);
                    profitQuarter = (decimal)randObj.Next(20000, 40000);
                    profitYear = (decimal)randObj.Next(50000, 90000);
                    employeeId = (int)randObj.Next(1, 99);
                    db.EmployeeFacts.Add(new Models.EmployeeFact { FullName = fullName, Quarter = quarter, Year = year, ProfitQuarter = profitQuarter, ProfitYear = profitYear, EmployeeID = employeeId });
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
                string fullName;
                int quarter;
                int year;
                decimal profitYear;
                decimal profitQuarter;
                int employeeFactId;

                randObj = new Random(1);

                string[] employeePlans_voc = { "Солодков М.А", "Трофимов Е.В", "Мартинович И.А", "Назаренко И.А", "Грамович А.В", "Брусенцова Ю.В", "Пархоменко П.И", "Колос В.В" };
                int count_employeePlans_voc = employeePlans_voc.GetLength(0);
                for (int employeePlanId = 1; employeePlanId < employeePlansCount; employeePlanId++)
                {
                    fullName = employeePlans_voc[randObj.Next(count_employeePlans_voc)] + employeePlanId.ToString();
                    quarter = (int)randObj.Next(50000, 70000);
                    year = (int)randObj.Next(80000, 120000);
                    profitQuarter = (decimal)randObj.Next(40000, 60000);
                    profitYear = (decimal)randObj.Next(70000, 110000);
                    employeeFactId = (int)randObj.Next(1, 99);
                    db.EmployeePlans.Add(new Models.EmployeePlan { FullName = fullName, Quarter = quarter, Year = year, ProfitQuarter = profitQuarter, ProfitYear = profitYear, EmployeeFactID = employeeFactId });
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
                decimal salary;
                decimal profit;
                int unitId;
                int age;

                randObj = new Random(1);

                string[] employee_voc = { "Солодков М.А", "Трофимов Е.В", "Мартинович И.А", "Назаренко И.А", "Грамович А.В", "Брусенцова Ю.В", "Пархоменко П.И", "Колос В.В" };
                int count_employee_voc = employee_voc.GetLength(0);
                for (int employeeID = 1; employeeID < employeesCount; employeeID++)
                {
                    fullName = employee_voc[randObj.Next(count_employee_voc)] + employeeID.ToString();
                    salary = (decimal)randObj.Next(1000, 2000);
                    profit = (decimal)randObj.Next(1000, 1500);
                    age = (int)randObj.Next(20, 55);
                    unitId = (int)randObj.Next(1, 99);
                    db.Employees.Add(new Models.Employee { FullName = fullName, Salary = salary, Profit = profit, Age = age, UnitId = unitId });
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
                string fullName;
                string progress;
                int employeeId;

                randObj = new Random(1);

                string[] employee_voc = { "Солодков М.А", "Трофимов Е.В", "Мартинович И.А", "Назаренко И.А", "Грамович А.В", "Брусенцова Ю.В", "Пархоменко П.И", "Колос В.В" };
                string[] progress_voc = { "выполнил работу вовремя", "просрочил дедлайн", "разлил кофе на клавиатуру", "подрался с коллегой за коржик", "получил прибавку к заралпте", "повысился в должности" };

                int count_employee_voc = employee_voc.GetLength(0);
                int count_progress_voc = progress_voc.GetLength(0);
                for (int progressEmployeeId = 1; progressEmployeeId < progressEmployeeCount; progressEmployeeId++)
                {
                    fullName = employee_voc[randObj.Next(count_employee_voc)] + progressEmployeeId.ToString();
                    progress = progress_voc[randObj.Next(count_progress_voc)];
                    employeeId = (int)randObj.Next(1, 99);
                    db.ProgressEmployees.Add(new Models.ProgressEmployee { FullName = fullName, Progress = progress, EmployeeID = employeeId });
                }
                db.SaveChanges();
            }
        }
        private static void InitializeUnits(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.Units.Any())
            {
                return;
            }
            else
            {
                string unitName;
                int countEmployee;

                Random randObj = new Random(1);

                string[] units_voc = { "администрация", "отдел кадров", "отдел маркетинга", "отдел продаж", "отдел финансов", "отдел логистики", "отдел IT", "отдел закупок", "отдел исследования и развития" };
                int count_units_voc = units_voc.GetLength(0);
                for (int unitId = 1; unitId < unitCount; unitId++)
                {
                    unitName = units_voc[randObj.Next(count_units_voc)] + unitId.ToString();
                    countEmployee = (int)randObj.Next(50, 150);
                    db.Units.Add(new Models.Unit {FullName = unitName, CountEmployee = countEmployee });
                }
                db.SaveChanges();
            }
        }
        private static void InitializeUnitValuationFacts(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.UnitValuationFacts.Any())
            {
                return;
            }
            else
            {
                string unitName;
                decimal profit;
                decimal salary;
                int unitId;

                randObj = new Random(1);

                string[] units_voc = { "администрация", "отдел кадров", "отдел маркетинга", "отдел продаж", "отдел финансов", "отдел логистики", "отдел IT", "отдел закупок", "отдел исследования и развития" };
                int count_units_voc = units_voc.GetLength(0);
                for(var unitValuationFactId = 1; unitValuationFactId < unitValuationFactsCount; unitValuationFactId++)
                {
                    unitName = units_voc[randObj.Next(count_units_voc)] + unitValuationFactId.ToString();
                    profit = (decimal)randObj.Next(700000, 1000000);
                    salary = (decimal)randObj.Next(850000, 1200000);
                    unitId = (int)randObj.Next(1, 99);
                    db.UnitValuationFacts.Add(new Models.UnitValuationFact { FullName = unitName, Profit = profit, Salary = salary, UnitID = unitId });
                }
                db.SaveChanges();
            }
        }
        private static void InitializeUnitValuationPlans(CompanyContext db)
        {
            db.Database.EnsureCreated();
            if (db.UnitValuationPlans.Any())
            {
                return;
            }
            else
            {
                string unitName;
                decimal profit;
                decimal salary;
                int unitValuationFactId;

                randObj = new Random(1);

                string[] units_voc = { "администрация", "отдел кадров", "отдел маркетинга", "отдел продаж", "отдел финансов", "отдел логистики", "отдел IT", "отдел закупок", "отдел исследования и развития" };
                int count_units_voc = units_voc.GetLength(0);
                for (var unitValuationPlanId = 1; unitValuationPlanId < unitValuationPlansCount; unitValuationPlanId++)
                {
                    unitName = units_voc[randObj.Next(count_units_voc)] + unitValuationPlanId.ToString();
                    profit = (decimal)randObj.Next(500000, 700000);
                    salary = (decimal)randObj.Next(950000, 1350000);
                    unitValuationFactId = (int)randObj.Next(1, 99);
                    db.UnitValuationPlans.Add(new Models.UnitValuationPlan { FullName = unitName, Profit = profit, Salary = salary, UnitValuationFactID = unitValuationFactId});
                }
                db.SaveChanges();
            }
        }
    }
}

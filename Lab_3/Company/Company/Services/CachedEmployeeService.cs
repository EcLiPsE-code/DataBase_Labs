using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.DATA;
using Company.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Company.Services
{
    public class CachedEmployeeService
    {
        private CompanyContext db;
        private IMemoryCache cache;
        private int rowsNumber;

        public CachedEmployeeService(CompanyContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            rowsNumber = 20;
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return db.Employees.Take(rowsNumber).ToList();
        }

        public void AddEmployee(string cacheKey)
        {
            IEnumerable<Employee> employee = db.Employees.Take(rowsNumber);

            cache.Set(cacheKey, employee, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

        }

        public IEnumerable<Employee> GetEmployee(string cacheKey)
        {
            IEnumerable<Employee> employees = null;
            if (!cache.TryGetValue(cacheKey, out employees))
            {
                employees = db.Employees.Take(rowsNumber).ToList();
                if (employees != null)
                {
                    cache.Set(cacheKey, employees,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            return employees;
        }
    }
}

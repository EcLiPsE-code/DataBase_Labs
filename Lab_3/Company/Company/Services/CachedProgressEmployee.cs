using Company.DATA;
using Company.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Services
{
    public class CachedProgressEmployee
    {
        private CompanyContext db;
        private IMemoryCache cache;
        private int rowsNumber;

        public CachedProgressEmployee(CompanyContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            rowsNumber = 20;
        }

        public IEnumerable<ProgressEmployee> GetEmployee()
        {
            return db.ProgressEmployees.Take(rowsNumber).ToList();
        }

        public void AddEmployee(string cacheKey)
        {
            IEnumerable<ProgressEmployee> employee = db.ProgressEmployees.Take(rowsNumber);

            cache.Set(cacheKey, employee, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

        }

        public IEnumerable<ProgressEmployee> GetEmployee(string cacheKey)
        {
            IEnumerable<ProgressEmployee> employees = null;
            if (!cache.TryGetValue(cacheKey, out employees))
            {
                employees = db.ProgressEmployees.Take(rowsNumber).ToList();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.DATA;
using Company.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Company.Services
{
    public class CachedUnitService
    {
        private CompanyContext db;
        private IMemoryCache cache;
        private int rowsNumber;

        public CachedUnitService(CompanyContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
            rowsNumber = 20;
        }

        public IEnumerable<Unit> GetUnit()
        {
            return db.Units.Take(rowsNumber).ToList();
        }

        public void AddUnit(string cacheKey)
        {
            IEnumerable<Unit> unit = db.Units.Take(rowsNumber);

            cache.Set(cacheKey, unit, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

        }

        public IEnumerable<Unit> GetUnit(string cacheKey)
        {
            IEnumerable<Unit> unit = null;
            if (!cache.TryGetValue(cacheKey, out unit))
            {
                unit = db.Units.Take(rowsNumber).ToList();
                if (unit != null)
                {
                    cache.Set(cacheKey, unit,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            return unit;
        }
    }
}

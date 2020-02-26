using CompanyASP.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyASP.Middleware
{
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate next;
        public DbInitializerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public Task Invoke(HttpContext context, IServiceProvider serviceProvider, CompanyContext dbContext)
        {
            if (!(context.Session.Keys.Contains("starting")))
            {
                DbInitializer.Initialize(dbContext);
                context.Session.SetString("starting", "Yes");
            }
            return this.next.Invoke(context);
        }
    }
}

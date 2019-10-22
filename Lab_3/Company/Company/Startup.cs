using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Company.DATA;
using Company.Services;
using Company.Models;
using Microsoft.AspNetCore.Http;

namespace Company
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            string connection = Configuration.GetConnectionString("SQLConnection");
            services.AddDbContext<CompanyContext>(options => options.UseSqlServer(connection));

            // внедрение зависимости OperationService
            services.AddTransient<CachedEmployeeService>();
            // добавление кэширования
            services.AddMemoryCache();
            // добавление поддержки сессии
            services.AddDistributedMemoryCache();
            services.AddSession();
            // внедрение зависимости CachedTanksService
            services.AddTransient<CachedUnitService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseRouting();

            //app.UseAuthorization();
            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            */
            //Запоминание в Session значений, введенных в форме
            app.Map("/form", (appBuilder) =>
                appBuilder.Run(async (context) =>
                {
                    Employee employee = context.Session.Get<Employee>("employee") ?? new Employee();

                    string strResponse = "<HTML><HEAD>" +
                    "<TITLE>Сотрудник</TITLE></HEAD>" +
                    "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                    "<BODY><FORM action ='/form' / >" +
                    "ФИО:<BR><INPUT type = 'text' name = 'FirstName' value = " + employee.FullName + ">" +
                    "<BR>Заработная плата:<BR><INPUT type = 'text' name = 'LastName' value = " + employee.Solution + " >" +
                    "<BR>Возраст:<BR><INPUT type = 'text' name = 'LastName' value = " + employee.Age + " >" +
                    "<BR><BR><INPUT type ='submit' value='Сохранить в Session'><INPUT type ='submit' value='Показать'></FORM>";
                    strResponse += "<BR><A href='/'>Главная</A>";
                    strResponse += "</BODY></HTML>";

                    string FullName = context.Request.Query["FullName"];
                    string Solution = context.Request.Query["Solution"];
                    string Age = context.Request.Query["Age"];
                    employee.FullName = FullName;
                    employee.Solution = decimal.Parse(Solution);
                    employee.Age = int.Parse(Age);
                    context.Session.Set<Employee>("employee", employee);

                    //Вывод динамической формы
                    await context.Response.WriteAsync(strResponse);
                })
            );;

            // Вывод информации о сотруднике
            app.Map("/info", (appBuilder) =>
            {
                appBuilder.Run(async (context) => {

                    // Формирование строки для вывода 
                    string strResponse = "<HTML><HEAD>" +
                    "<TITLE>Информация</TITLE></HEAD>" +
                    "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                    "<BODY><H1>Нет информации о сотруднике</H1></BODY></HTML>";

                    // Вывод данных
                    await context.Response.WriteAsync(strResponse);
                });
            });

            //Вывод записей таблицы Employee с использованием кэширования 
            app.Run((context) =>
            {
                CachedEmployeeService cachedEmployeeService = context.RequestServices.GetService<CachedEmployeeService>();
                IEnumerable<Employee> employees = cachedEmployeeService.GetEmployee("aPEsRJrLUsIwOiMBbj");
                string HtmlString = "<HTML><HEAD><TITLE>Сотрудники</TITLE></HEAD>" +
                "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                "<BODY><H1>Список Сотрудников</H1>" +
                "<TABLE BORDER=1>";
                HtmlString += "<TH>";
                HtmlString += "<TD>Код</TD>";
                HtmlString += "<TD>ФИО</TD>";
                HtmlString += "<TD>ЗАроботная плата</TD>";
                HtmlString += "<TD>Затраты</TD>";
                HtmlString += "<TD>Возраст</TD>";
                HtmlString += "</TH>";
                foreach (var employee in employees)
                {
                    HtmlString += "<TR>";
                    HtmlString += "<TD>" + employee.EmployeeId + "</TD>";
                    HtmlString += "<TD>" + employee.FullName + "</TD>";
                    HtmlString += "<TD>" + employee.Solution+ "</TD>";
                    HtmlString += "<TD>" + employee.Profit + "</TD>";
                    HtmlString += "<TD>" + employee.Age.ToString() + "</TD>";
                    HtmlString += "</TR>";
                }
                HtmlString += "</TABLE>";

                HtmlString += "<BR><A href='/'>Главная</A></BR>";
                HtmlString += "<BR><A href='/form'>Данные пользователя</A></BR>";

                HtmlString += "</TABLE></HTML>";

                return context.Response.WriteAsync(HtmlString);

            });
        }
    }
}

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

            // ��������� ����������� OperationService
            services.AddTransient<CachedEmployeeService>();
            // ���������� �����������
            services.AddMemoryCache();
            // ���������� ��������� ������
            services.AddDistributedMemoryCache();
            services.AddSession();
            // ��������� ����������� CachedTanksService
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
            //����������� � Session ��������, ��������� � �����
            app.Map("/form", (appBuilder) =>
                appBuilder.Run(async (context) =>
                {
                    Employee employee = context.Session.Get<Employee>("employee") ?? new Employee();

                    string strResponse = "<HTML><HEAD>" +
                    "<TITLE>���������</TITLE></HEAD>" +
                    "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                    "<BODY><FORM action ='/form' / >" +
                    "���:<BR><INPUT type = 'text' name = 'FirstName' value = " + employee.FullName + ">" +
                    "<BR>���������� �����:<BR><INPUT type = 'text' name = 'LastName' value = " + employee.Solution + " >" +
                    "<BR>�������:<BR><INPUT type = 'text' name = 'LastName' value = " + employee.Age + " >" +
                    "<BR><BR><INPUT type ='submit' value='��������� � Session'><INPUT type ='submit' value='��������'></FORM>";
                    strResponse += "<BR><A href='/'>�������</A>";
                    strResponse += "</BODY></HTML>";

                    string FullName = context.Request.Query["FullName"];
                    string Solution = context.Request.Query["Solution"];
                    string Age = context.Request.Query["Age"];
                    employee.FullName = FullName;
                    employee.Solution = decimal.Parse(Solution);
                    employee.Age = int.Parse(Age);
                    context.Session.Set<Employee>("employee", employee);

                    //����� ������������ �����
                    await context.Response.WriteAsync(strResponse);
                })
            );;

            // ����� ���������� � ����������
            app.Map("/info", (appBuilder) =>
            {
                appBuilder.Run(async (context) => {

                    // ������������ ������ ��� ������ 
                    string strResponse = "<HTML><HEAD>" +
                    "<TITLE>����������</TITLE></HEAD>" +
                    "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                    "<BODY><H1>��� ���������� � ����������</H1></BODY></HTML>";

                    // ����� ������
                    await context.Response.WriteAsync(strResponse);
                });
            });

            //����� ������� ������� Employee � �������������� ����������� 
            app.Run((context) =>
            {
                CachedEmployeeService cachedEmployeeService = context.RequestServices.GetService<CachedEmployeeService>();
                IEnumerable<Employee> employees = cachedEmployeeService.GetEmployee("aPEsRJrLUsIwOiMBbj");
                string HtmlString = "<HTML><HEAD><TITLE>����������</TITLE></HEAD>" +
                "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                "<BODY><H1>������ �����������</H1>" +
                "<TABLE BORDER=1>";
                HtmlString += "<TH>";
                HtmlString += "<TD>���</TD>";
                HtmlString += "<TD>���</TD>";
                HtmlString += "<TD>���������� �����</TD>";
                HtmlString += "<TD>�������</TD>";
                HtmlString += "<TD>�������</TD>";
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

                HtmlString += "<BR><A href='/'>�������</A></BR>";
                HtmlString += "<BR><A href='/form'>������ ������������</A></BR>";

                HtmlString += "</TABLE></HTML>";

                return context.Response.WriteAsync(HtmlString);

            });
        }
    }
}

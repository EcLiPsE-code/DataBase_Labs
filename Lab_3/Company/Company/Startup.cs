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
using System.Web.Mvc;

namespace Company
{
    public class Startup
    {
        private const string LINKS = "<br><a href='info'>���������� � �������</a>" +
                                     "<br><a href='session-employee'>���������� ������ � ������� �����</a>" +
                                     "<br><a href='coockie-employee'>���������� ������ � ������� ����</a>" +
                                     "<br><a href='search-employee'>����� ����������� �� ��������</a>" +
                                     "<br><a href='table-employee'>����������</a>" +
                                     "<br><a href='table-progressEmployee'>���������� �����������</a>" +
                                     "<br><a href='table-unit'>������������� ��������</a>";
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
            //���������� �����������
            services.AddMemoryCache();
            //���������� ��������� ������
            services.AddDistributedMemoryCache();
            services.AddSession();
            //��������� ������������
            services.AddTransient<CachedUnitService>();
            services.AddTransient<CachedEmployeeService>();
            services.AddTransient<CachedProgressEmployee>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.Map("/info", Info); //����� ���������� � �������
            app.Map("/table-progressEmployee", TableProgressEmployee); //����� ���������� � ���������� �����������
            app.Map("/table-unit", TableUnit); //����� ���������� � �������������� ��������
            app.Map("/search-employee", SearchEmployee); //����� ���������� �� ��������
            app.Map("/session-employee", SessionEmployee); //���������� ������ � ������� Session
            app.Map("/coockie-employee", CoockieEmployee); //���������� ������ � ������� coockie
            //����� ������� �� ������� Employee � �������������� �����������
            app.Run( async (context) =>
            {
                CachedEmployeeService cachedEmployeeService = context.RequestServices.GetService<CachedEmployeeService>();
                IEnumerable<Employee> employees = cachedEmployeeService.GetEmployee("aPEsRJrLUsIwOiMBbj");
                string HtmlString = "<HTML><HEAD><TITLE>����������</TITLE></HEAD>" +
                "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                "<BODY><H1>������ �����������</H1>" +
                "<TABLE BORDER=1>";
                HtmlString += "<TR>";
                HtmlString += "<TD>Id ����������</TD>";
                HtmlString += "<TD>��� ����������</TD>";
                HtmlString += "<TD>���������� �����</TD>";
                HtmlString += "<TD>�������</TD>";
                HtmlString += "<TD>�������</TD>";
                HtmlString += "</TR>";
                foreach (var employee in employees)
                {
                    HtmlString += "<TR>";
                    HtmlString += "<TD>" + employee.EmployeeId + "</TD>";
                    HtmlString += "<TD>" + employee.FullName + "</TD>";
                    HtmlString += "<TD>" + employee.Solution + "</TD>";
                    HtmlString += "<TD>" + employee.Profit + "</TD>";
                    HtmlString += "<TD>" + employee.Age.ToString() + "</TD>";
                    HtmlString += "</TR>";
                }
                HtmlString += "</TABLE>";

                HtmlString += LINKS;
               
                HtmlString += "</TABLE></HTML>";

                await context.Response.WriteAsync(HtmlString);
            });
        }

        private static void Info(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                string HtmlString = "<HTML><HEAD>" +
                "<TITLE>���������� � ����������</TITLE></HEAD>" +
                "<META http-equiv='Content-Type' content='text/html'; charset='utf-8' />" +
                "<BODY><H1>����������</H1><P>Headers �������: " + context.Response.Headers.ToString() + "</P>" +
                "<P>������: " + context.Response.StatusCode + "</P>" +
                "<P>IP ������: " + context.Request.HttpContext.Connection.RemoteIpAddress + "</P>" +
                "</BODY></HTML>";

                HtmlString += LINKS;
                await context.Response.WriteAsync(HtmlString);
            });
        }
        private static void TableProgressEmployee(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                CachedProgressEmployee cachedProgressEmployee = context.RequestServices.GetService<CachedProgressEmployee>();
                IEnumerable<ProgressEmployee> progressEmployees = cachedProgressEmployee.GetEmployee("jSpBdMSFHvWTdJwB");
                string HtmlString = "<HTML><HEAD><TITLE>���������� �����������</TITLE></HEAD>" +
                "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                "<BODY><H1>���������� �����������</H1>" +
                "<TABLE BORDER=1>";
                HtmlString += "<TR>";
                HtmlString += "<TD>��� ����������</TD>";
                HtmlString += "<TD>��� ����������</TD>";
                HtmlString += "<TD>����������</TD>";
                HtmlString += "<TD>��� ����������</TD>";
                HtmlString += "</TR>";
                foreach (var progressEmployee in progressEmployees)
                {
                    HtmlString += "<TR>";
                    HtmlString += "<TD>" + progressEmployee.ProgressEmployeeId + "</TD>";
                    HtmlString += "<TD>" + progressEmployee.FullName + "</TD>";
                    HtmlString += "<TD>" + progressEmployee.Progress + "</TD>";
                    HtmlString += "<TD>" + progressEmployee.EmployeeId + "</TD>";
                    HtmlString += "</TR>";
                }
                HtmlString += "</TABLE>";

                HtmlString += LINKS;

                HtmlString += "</TABLE></HTML>";

                await context.Response.WriteAsync(HtmlString);
            });
        }
        private static void TableUnit(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                CachedUnitService cachedUnitService = context.RequestServices.GetService<CachedUnitService>();
                IEnumerable<Unit> units = cachedUnitService.GetUnit("dDAogoAEU");
                string HtmlString = "<HTML><HEAD><TITLE>������������� ��������</TITLE></HEAD>" +
                "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                "<BODY><H1>������������� ��������</H1>" +
                "<TABLE BORDER=1>";
                HtmlString += "<TR>";
                HtmlString += "<TD>��� �������������</TD>";
                HtmlString += "<TD>������������ �������������</TD>";
                HtmlString += "<TD>���������� �����������</TD>";
                HtmlString += "</TR>";
                foreach (var unit in units)
                {
                    HtmlString += "<TR>";
                    HtmlString += "<TD>" + unit.UnitId + "</TD>";
                    HtmlString += "<TD>" + unit.FullName + "</TD>";
                    HtmlString += "<TD>" + unit.CountEmployees + "</TD>";
                    HtmlString += "</TR>";
                }
                HtmlString += "</TABLE>";

                HtmlString += LINKS;

                HtmlString += "</TABLE></HTML>";

                await context.Response.WriteAsync(HtmlString);
            });
        }
        private static void SearchEmployee(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                string fullName = null;
                fullName = context.Request.Query["FullName"];
                string HtmlString = "<HTML><HEAD><TITLE>������������� ��������</TITLE></HEAD>" +
                "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                "<body><form action = '/search-employee'>" +
                "���:<br><input type = 'text' name = 'fullName' value = "+ fullName + ">" + "<br>" + 
                "<br><input type = 'submit' value = 'Submit'></form></br>";
                if (fullName != null)
                {
                    CachedEmployeeService cachedEmployeeService = context.RequestServices.GetService<CachedEmployeeService>();
                    var employees = cachedEmployeeService.ReadEmployee(fullName);
                    HtmlString = "<HTML><HEAD><TITLE>���������� ��������</TITLE></HEAD>" +
                    "<META http-equiv='Content-Type' content='text/html; charset=utf-8'/>" +
                    "<BODY><H1>���������</H1>" +
                    "<TABLE BORDER=1>";
                    HtmlString += "<TR>";
                    HtmlString += "<TD>��� ����������</TD>";
                    HtmlString += "<TD>��� ����������</TD>";
                    HtmlString += "<TD>�� ����������</TD>";
                    HtmlString += "<TD>������� �������� �� ����������</TD>";
                    HtmlString += "<TD>������� ����������</TD>";
                    HtmlString += "</TR>";
                    foreach (Employee employee in employees)
                    {
                        HtmlString += "<TR>";
                        HtmlString += "<TD>" + employee.EmployeeId + "</TD>";
                        HtmlString += "<TD>" + employee.FullName + "</TD>";
                        HtmlString += "<TD>" + employee.Solution + "</TD>";
                        HtmlString += "<TD>" + employee.Profit + "</TD>";
                        HtmlString += "<TD>" + employee.Age + "</TD>";
                        HtmlString += "</TR>";
                    }
                    HtmlString += "</TABLE>";
                    HtmlString += LINKS;
                    HtmlString += "</TABLE></HTML>" + "<br>";
                }
                await context.Response.WriteAsync(HtmlString);
            });
        }
        //����������� � Session ��������, ��������� � �����
        private static void SessionEmployee(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                string fullName = "";
                if (context.Session.Keys.Contains("fullName"))
                {
                    fullName = context.Session.GetString("fullName");
                }

                string strResponse = "<HTML><HEAD>" +
                    "<TITLE>������������ Session</TITLE></HEAD>" +
                    "<META http-equiv='Content-Type' content='text/html'; charset='utf-8'/>" +
                    "<BODY><FORM action ='/session-employee' / >" +
                    "���:<BR><INPUT type = 'text' name = 'fullName' value = " + fullName + ">" +
                    "<BR><BR><INPUT type ='submit' value='��������� � Session'><INPUT type ='submit' value='��������'></FORM>";
                strResponse += "<BR><A href='/'>�������</A>";
                //strResponse += LINKS + "</BODY></HTML>";

                if (context.Request.Query.ContainsKey("fullName") && context.Request.Query["fullName"] != "")
                {
                    context.Session.SetString("fullName", context.Request.Query["fullName"]);
                }

                await context.Response.WriteAsync(strResponse);
            });
        }
        private static void CoockieEmployee(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                string fullName;
                context.Request.Cookies.TryGetValue("fullName", out fullName);
                string strResponse = "<HTML><HEAD>" +
                    "<TITLE>������������ Coockie</TITLE></HEAD>" +
                    "<META http-equiv='Content-Type' content='text/html'; charset='utf-8'/>" +
                    "<BODY><FORM action ='/coockie-employee' / >" +
                    "���:<BR><INPUT type = 'text' name = 'fullName' value = " + fullName + ">" +
                    "<BR><BR><INPUT type ='submit' value='��������� � Coockie'><INPUT type ='submit' value='��������'></FORM>";
                strResponse += "<BR><A href='/'>�������</A>";

                if (context.Request.Query.ContainsKey("fullName"))
                {
                    context.Response.Cookies.Append("fullName", context.Request.Query["fullName"]);
                }
                await context.Response.WriteAsync(strResponse);
            });
        }
    }
}

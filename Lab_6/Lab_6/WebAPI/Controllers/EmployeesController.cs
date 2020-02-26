using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyASP.Data;
using CompanyASP.Models;
using CompanyASP.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyContext _context;
        public EmployeesController(CompanyContext context)
        {
            _context = context;
        }

        //получение всех сотрудников
        // GET: api/Employees
        [HttpGet]
        [Produces("application/json")]
        public List<EmployeeViewModel> Get()
        {
            var ovm = _context.Employees.Include(o => o.Departament).Select(t =>
                new EmployeeViewModel
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Salary = t.Salary,
                    Age = t.Age,
                    Raiting = t.Raiting,
                    DepartamentId = t.DepartamentId
                });
            return ovm.OrderByDescending(t => t.Id).Take(20).ToList();
        }

        // GET: api/Employees/5
        [HttpGet("employees")]
        [Produces("application/json")]
        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        [HttpGet("departaments")]
        [Produces("application/json")]
        public IEnumerable<Departament> GetDepartaments()
        {
            return _context.Departaments.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployees(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return new ObjectResult(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            if (!_context.Employees.Any(x => x.Id == employee.Id))
            {
                return NotFound();
            }
            _context.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
    }
}

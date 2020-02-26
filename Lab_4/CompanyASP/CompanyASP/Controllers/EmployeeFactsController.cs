using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyASP.Data;
using CompanyASP.Models;

namespace CompanyASP.Controllers
{
    public class EmployeeFactsController : Controller
    {
        private readonly CompanyContext _context;

        public EmployeeFactsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: EmployeeFacts
        public async Task<IActionResult> Index()
        {
            var companyContext = _context.EmployeeFacts.Include(e => e.Employee);
            return View(await companyContext.ToListAsync());
        }

        // GET: EmployeeFacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFact = await _context.EmployeeFacts
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeFactID == id);
            if (employeeFact == null)
            {
                return NotFound();
            }

            return View(employeeFact);
        }

        // GET: EmployeeFacts/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID");
            return View();
        }

        // POST: EmployeeFacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeFactID,FullName,Quarter,Year,ProfitYear,ProfitQuarter,EmployeeID")] EmployeeFact employeeFact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeFact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", employeeFact.EmployeeID);
            return View(employeeFact);
        }

        // GET: EmployeeFacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFact = await _context.EmployeeFacts.FindAsync(id);
            if (employeeFact == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", employeeFact.EmployeeID);
            return View(employeeFact);
        }

        // POST: EmployeeFacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeFactID,FullName,Quarter,Year,ProfitYear,ProfitQuarter,EmployeeID")] EmployeeFact employeeFact)
        {
            if (id != employeeFact.EmployeeFactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeFact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeFactExists(employeeFact.EmployeeFactID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", employeeFact.EmployeeID);
            return View(employeeFact);
        }

        // GET: EmployeeFacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFact = await _context.EmployeeFacts
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeFactID == id);
            if (employeeFact == null)
            {
                return NotFound();
            }

            return View(employeeFact);
        }

        // POST: EmployeeFacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeFact = await _context.EmployeeFacts.FindAsync(id);
            _context.EmployeeFacts.Remove(employeeFact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeFactExists(int id)
        {
            return _context.EmployeeFacts.Any(e => e.EmployeeFactID == id);
        }
    }
}

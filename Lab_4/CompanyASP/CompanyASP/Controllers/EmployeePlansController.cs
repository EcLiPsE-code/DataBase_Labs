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
    public class EmployeePlansController : Controller
    {
        private readonly CompanyContext _context;

        public EmployeePlansController(CompanyContext context)
        {
            _context = context;
        }

        // GET: EmployeePlans
        public async Task<IActionResult> Index()
        {
            var companyContext = _context.EmployeePlans.Include(e => e.EmployeeFact);
            return View(await companyContext.ToListAsync());
        }

        // GET: EmployeePlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePlan = await _context.EmployeePlans
                .Include(e => e.EmployeeFact)
                .FirstOrDefaultAsync(m => m.EmployeePlanID == id);
            if (employeePlan == null)
            {
                return NotFound();
            }

            return View(employeePlan);
        }

        // GET: EmployeePlans/Create
        public IActionResult Create()
        {
            ViewData["EmployeeFactID"] = new SelectList(_context.EmployeeFacts, "EmployeeFactID", "EmployeeFactID");
            return View();
        }

        // POST: EmployeePlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeePlanID,FullName,Quarter,Year,ProfitQuarter,ProfitYear,EmployeeFactID")] EmployeePlan employeePlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeePlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeFactID"] = new SelectList(_context.EmployeeFacts, "EmployeeFactID", "EmployeeFactID", employeePlan.EmployeeFactID);
            return View(employeePlan);
        }

        // GET: EmployeePlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePlan = await _context.EmployeePlans.FindAsync(id);
            if (employeePlan == null)
            {
                return NotFound();
            }
            ViewData["EmployeeFactID"] = new SelectList(_context.EmployeeFacts, "EmployeeFactID", "EmployeeFactID", employeePlan.EmployeeFactID);
            return View(employeePlan);
        }

        // POST: EmployeePlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeePlanID,FullName,Quarter,Year,ProfitQuarter,ProfitYear,EmployeeFactID")] EmployeePlan employeePlan)
        {
            if (id != employeePlan.EmployeePlanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePlanExists(employeePlan.EmployeePlanID))
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
            ViewData["EmployeeFactID"] = new SelectList(_context.EmployeeFacts, "EmployeeFactID", "EmployeeFactID", employeePlan.EmployeeFactID);
            return View(employeePlan);
        }

        // GET: EmployeePlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePlan = await _context.EmployeePlans
                .Include(e => e.EmployeeFact)
                .FirstOrDefaultAsync(m => m.EmployeePlanID == id);
            if (employeePlan == null)
            {
                return NotFound();
            }

            return View(employeePlan);
        }

        // POST: EmployeePlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeePlan = await _context.EmployeePlans.FindAsync(id);
            _context.EmployeePlans.Remove(employeePlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePlanExists(int id)
        {
            return _context.EmployeePlans.Any(e => e.EmployeePlanID == id);
        }
    }
}

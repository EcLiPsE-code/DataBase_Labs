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
    public class UnitValuationPlansController : Controller
    {
        private readonly CompanyContext _context;

        public UnitValuationPlansController(CompanyContext context)
        {
            _context = context;
        }

        // GET: UnitValuationPlans
        public async Task<IActionResult> Index()
        {
            var companyContext = _context.UnitValuationPlans.Include(u => u.UnitValuationFact);
            return View(await companyContext.ToListAsync());
        }

        // GET: UnitValuationPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitValuationPlan = await _context.UnitValuationPlans
                .Include(u => u.UnitValuationFact)
                .FirstOrDefaultAsync(m => m.UnitValuationPlanID == id);
            if (unitValuationPlan == null)
            {
                return NotFound();
            }

            return View(unitValuationPlan);
        }

        // GET: UnitValuationPlans/Create
        public IActionResult Create()
        {
            ViewData["UnitValuationFactID"] = new SelectList(_context.UnitValuationFacts, "UnitValuationFactID", "UnitValuationFactID");
            return View();
        }

        // POST: UnitValuationPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitValuationPlanID,FullName,Profit,Salary,UnitValuationFactID")] UnitValuationPlan unitValuationPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitValuationPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitValuationFactID"] = new SelectList(_context.UnitValuationFacts, "UnitValuationFactID", "UnitValuationFactID", unitValuationPlan.UnitValuationFactID);
            return View(unitValuationPlan);
        }

        // GET: UnitValuationPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitValuationPlan = await _context.UnitValuationPlans.FindAsync(id);
            if (unitValuationPlan == null)
            {
                return NotFound();
            }
            ViewData["UnitValuationFactID"] = new SelectList(_context.UnitValuationFacts, "UnitValuationFactID", "UnitValuationFactID", unitValuationPlan.UnitValuationFactID);
            return View(unitValuationPlan);
        }

        // POST: UnitValuationPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitValuationPlanID,FullName,Profit,Salary,UnitValuationFactID")] UnitValuationPlan unitValuationPlan)
        {
            if (id != unitValuationPlan.UnitValuationPlanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitValuationPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitValuationPlanExists(unitValuationPlan.UnitValuationPlanID))
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
            ViewData["UnitValuationFactID"] = new SelectList(_context.UnitValuationFacts, "UnitValuationFactID", "UnitValuationFactID", unitValuationPlan.UnitValuationFactID);
            return View(unitValuationPlan);
        }

        // GET: UnitValuationPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitValuationPlan = await _context.UnitValuationPlans
                .Include(u => u.UnitValuationFact)
                .FirstOrDefaultAsync(m => m.UnitValuationPlanID == id);
            if (unitValuationPlan == null)
            {
                return NotFound();
            }

            return View(unitValuationPlan);
        }

        // POST: UnitValuationPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitValuationPlan = await _context.UnitValuationPlans.FindAsync(id);
            _context.UnitValuationPlans.Remove(unitValuationPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitValuationPlanExists(int id)
        {
            return _context.UnitValuationPlans.Any(e => e.UnitValuationPlanID == id);
        }
    }
}

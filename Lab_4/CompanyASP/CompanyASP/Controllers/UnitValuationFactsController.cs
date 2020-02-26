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
    public class UnitValuationFactsController : Controller
    {
        private readonly CompanyContext _context;

        public UnitValuationFactsController(CompanyContext context)
        {
            _context = context;
        }

        // GET: UnitValuationFacts
        public async Task<IActionResult> Index()
        {
            var companyContext = _context.UnitValuationFacts.Include(u => u.Unit);
            return View(await companyContext.ToListAsync());
        }

        // GET: UnitValuationFacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitValuationFact = await _context.UnitValuationFacts
                .Include(u => u.Unit)
                .FirstOrDefaultAsync(m => m.UnitValuationFactID == id);
            if (unitValuationFact == null)
            {
                return NotFound();
            }

            return View(unitValuationFact);
        }

        // GET: UnitValuationFacts/Create
        public IActionResult Create()
        {
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID");
            return View();
        }

        // POST: UnitValuationFacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitValuationFactID,FullName,Profit,Salary,UnitID")] UnitValuationFact unitValuationFact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitValuationFact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", unitValuationFact.UnitID);
            return View(unitValuationFact);
        }

        // GET: UnitValuationFacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitValuationFact = await _context.UnitValuationFacts.FindAsync(id);
            if (unitValuationFact == null)
            {
                return NotFound();
            }
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", unitValuationFact.UnitID);
            return View(unitValuationFact);
        }

        // POST: UnitValuationFacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitValuationFactID,FullName,Profit,Salary,UnitID")] UnitValuationFact unitValuationFact)
        {
            if (id != unitValuationFact.UnitValuationFactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitValuationFact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitValuationFactExists(unitValuationFact.UnitValuationFactID))
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
            ViewData["UnitID"] = new SelectList(_context.Units, "UnitID", "UnitID", unitValuationFact.UnitID);
            return View(unitValuationFact);
        }

        // GET: UnitValuationFacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitValuationFact = await _context.UnitValuationFacts
                .Include(u => u.Unit)
                .FirstOrDefaultAsync(m => m.UnitValuationFactID == id);
            if (unitValuationFact == null)
            {
                return NotFound();
            }

            return View(unitValuationFact);
        }

        // POST: UnitValuationFacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitValuationFact = await _context.UnitValuationFacts.FindAsync(id);
            _context.UnitValuationFacts.Remove(unitValuationFact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitValuationFactExists(int id)
        {
            return _context.UnitValuationFacts.Any(e => e.UnitValuationFactID == id);
        }
    }
}

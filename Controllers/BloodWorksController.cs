using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedChartBloodWork.Data;
using MedChartBloodWork.Models;

namespace MedChartBloodWork.Controllers
{
    public class BloodWorksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodWorksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BloodWorks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BloodWork.Include(b => b.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BloodWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodWork = await _context.BloodWork
                .Include(b => b.ApplicationUser)
                .FirstOrDefaultAsync(m => m.BloodWorkID == id);
            if (bloodWork == null)
            {
                return NotFound();
            }

            return View(bloodWork);
        }

        // GET: BloodWorks/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserID"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: BloodWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BloodWorkID,DateCreated,ExamDate,ResultDate,Description,Hemoglobin,Hematocrit,WhiteBloodCellCount,RedBloodCellCount,ApplicationUserID")] BloodWork bloodWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserID"] = new SelectList(_context.ApplicationUser, "Id", "Id", bloodWork.ApplicationUserID);
            return View(bloodWork);
        }

        // GET: BloodWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodWork = await _context.BloodWork.FindAsync(id);
            if (bloodWork == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserID"] = new SelectList(_context.ApplicationUser, "Id", "Id", bloodWork.ApplicationUserID);
            return View(bloodWork);
        }

        // POST: BloodWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BloodWorkID,DateCreated,ExamDate,ResultDate,Description,Hemoglobin,Hematocrit,WhiteBloodCellCount,RedBloodCellCount,ApplicationUserID")] BloodWork bloodWork)
        {
            if (id != bloodWork.BloodWorkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodWorkExists(bloodWork.BloodWorkID))
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
            ViewData["ApplicationUserID"] = new SelectList(_context.ApplicationUser, "Id", "Id", bloodWork.ApplicationUserID);
            return View(bloodWork);
        }

        // GET: BloodWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodWork = await _context.BloodWork
                .Include(b => b.ApplicationUser)
                .FirstOrDefaultAsync(m => m.BloodWorkID == id);
            if (bloodWork == null)
            {
                return NotFound();
            }

            return View(bloodWork);
        }

        // POST: BloodWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloodWork = await _context.BloodWork.FindAsync(id);
            _context.BloodWork.Remove(bloodWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodWorkExists(int id)
        {
            return _context.BloodWork.Any(e => e.BloodWorkID == id);
        }
    }
}

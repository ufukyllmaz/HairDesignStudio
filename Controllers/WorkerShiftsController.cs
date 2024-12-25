using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairDesginStudio.Data;
using HairDesginStudio.Models;
using Microsoft.AspNetCore.Authorization;

namespace HairDesginStudio.Controllers
{
    [Authorize]
    public class WorkerShiftsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkerShiftsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkerShifts
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkerShifts.ToListAsync());
        }

        // GET: WorkerShifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerShifts = await _context.WorkerShifts
                .FirstOrDefaultAsync(m => m.WorkerId == id);
            if (workerShifts == null)
            {
                return NotFound();
            }

            return View(workerShifts);
        }

        // GET: WorkerShifts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkerShifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkerId,WorkerName,WorkerSurname,WorkStartTime,WorkEndTime")] WorkerShifts workerShifts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workerShifts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workerShifts);
        }

        // GET: WorkerShifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerShifts = await _context.WorkerShifts.FindAsync(id);
            if (workerShifts == null)
            {
                return NotFound();
            }
            return View(workerShifts);
        }

        // POST: WorkerShifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkerId,WorkerName,WorkerSurname,WorkStartTime,WorkEndTime")] WorkerShifts workerShifts)
        {
            if (id != workerShifts.WorkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workerShifts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerShiftsExists(workerShifts.WorkerId))
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
            return View(workerShifts);
        }

        // GET: WorkerShifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerShifts = await _context.WorkerShifts
                .FirstOrDefaultAsync(m => m.WorkerId == id);
            if (workerShifts == null)
            {
                return NotFound();
            }

            return View(workerShifts);
        }

        // POST: WorkerShifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workerShifts = await _context.WorkerShifts.FindAsync(id);
            if (workerShifts != null)
            {
                _context.WorkerShifts.Remove(workerShifts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerShiftsExists(int id)
        {
            return _context.WorkerShifts.Any(e => e.WorkerId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairDesignStudio.Data;
using HairDesignStudio.Models;
using Microsoft.AspNetCore.Authorization;

namespace HairDesignStudio.Controllers
{
    [Authorize]
    public class WorkerOperationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkerOperationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkerOperations
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkerOperations.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        // GET: WorkerOperations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerOperations = await _context.WorkerOperations
                .FirstOrDefaultAsync(m => m.WorkerId == id);
            if (workerOperations == null)
            {
                return NotFound();
            }

            return View(workerOperations);
        }

        [HttpPost]
        public IActionResult UpdateSurnames(string WorkerName)
        {
            // Seçilen isme göre soyisimleri getir
            var workerNames = _context.Workers
                .Select(w => w.WorkerName)
                .Distinct()
                .ToList();
            ViewBag.WorkerNames = new SelectList(workerNames, WorkerName);

            var surnames = _context.Workers
                .Where(w => w.WorkerName == WorkerName)
                .Select(w => w.WorkerSurname)
                .ToList();
            ViewBag.WorkerSurnames = new SelectList(surnames);

            var operations = _context.Operations
                .Select(o => o.OperationName)
                .ToList();
            ViewBag.Operations = new SelectList(operations);

            return View("Create", new WorkerOperations { WorkerName = WorkerName });
        }

        [Authorize(Roles = "Admin")]
        // GET: WorkerOperations/Create
        public IActionResult Create()
        {
            var operations = _context.Operations.Select(o => o.OperationName).ToList();
            var workerNames = _context.Workers.Select(w => w.WorkerName).Distinct().ToList();

            ViewBag.WorkerNames = new SelectList(workerNames);
            ViewBag.Operations = new MultiSelectList(operations);
            return View(new WorkerOperations());
        }

        // POST: WorkerOperations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkerId,WorkerName,WorkerSurname,WorkerHasOperations")] WorkerOperations workerOperations)
        {
            if (ModelState.IsValid)
            {
                var worker = await _context.Workers
                            .FirstOrDefaultAsync(w => w.WorkerName == workerOperations.WorkerName 
                                                && w.WorkerSurname == workerOperations.WorkerSurname);
                        
                if (worker != null)
                {
                    workerOperations.workers = worker;
                    // Her bir operasyon için ayrı kayıt oluştur
                    foreach (var operation in workerOperations.WorkerHasOperations)
                    {
                        var workerOp = new WorkerOperations
                        {
                            WorkerName = workerOperations.WorkerName,
                            WorkerSurname = workerOperations.WorkerSurname,
                            workers = worker,
                            WorkerHasOperations = new List<string> { operation }
                        };
                        _context.Add(workerOp);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            var operations = _context.Operations.Select(o => o.OperationName).ToList();
            ViewBag.Operations = new MultiSelectList(operations);
            var workerNames = _context.Workers
                .Select(w => w.WorkerName)
                .Distinct()
                .ToList();
            ViewBag.WorkerNames = new SelectList(workerNames);

            if (!string.IsNullOrEmpty(workerOperations.WorkerName))
            {
                var surnames = _context.Workers
                    .Where(w => w.WorkerName == workerOperations.WorkerName)
                    .Select(w => w.WorkerSurname)
                    .ToList();
                ViewBag.WorkerSurnames = new SelectList(surnames);
            }
            return View(workerOperations);
        }

        [Authorize(Roles = "Admin")]
        // GET: WorkerOperations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerOperations = await _context.WorkerOperations
                .Include(w => w.workers)
                .FirstOrDefaultAsync(w => w.WorkerId == id);

            if (workerOperations == null)
            {
                return NotFound();
            }

            // Populate all dropdown lists
            var operations = _context.Operations.Select(o => o.OperationName).ToList();
            var workerNames = _context.Workers.Select(w => w.WorkerName).Distinct().ToList();
            var surnames = _context.Workers
                .Where(w => w.WorkerName == workerOperations.WorkerName)
                .Select(w => w.WorkerSurname)
                .ToList();
            
            ViewBag.WorkerNames = new SelectList(workerNames, workerOperations.WorkerName);
            ViewBag.WorkerSurnames = new SelectList(surnames, workerOperations.WorkerSurname);
            ViewBag.Operations = new SelectList(operations, workerOperations.WorkerHasOperations);

            return View(workerOperations);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("WorkerId,WorkerName,WorkerSurname,WorkerHasOperations")] WorkerOperations workerOperations)
        {
            if (id != workerOperations.WorkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var worker = await _context.Workers
                        .FirstOrDefaultAsync(w => w.WorkerName == workerOperations.WorkerName
                                            && w.WorkerSurname == workerOperations.WorkerSurname);

                    if (worker != null)
                    {
                        workerOperations.workers = worker;
                        _context.Update(workerOperations);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerOperationsExists(workerOperations.WorkerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            var operations = _context.Operations.Select(o => o.OperationName).ToList();
            var workerNames = _context.Workers.Select(w => w.WorkerName).Distinct().ToList();
            var surnames = _context.Workers
                .Where(w => w.WorkerName == workerOperations.WorkerName)
                .Select(w => w.WorkerSurname)
                .ToList();

            ViewBag.WorkerNames = new SelectList(workerNames, workerOperations.WorkerName);
            ViewBag.WorkerSurnames = new SelectList(surnames, workerOperations.WorkerSurname);
            ViewBag.Operations = new SelectList(operations, workerOperations.WorkerHasOperations);
            
            return View(workerOperations);
        }

        [Authorize(Roles = "Admin")]
        // GET: WorkerOperations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerOperations = await _context.WorkerOperations
                .FirstOrDefaultAsync(m => m.WorkerId == id);
            if (workerOperations == null)
            {
                return NotFound();
            }

            return View(workerOperations);
        }

        // POST: WorkerOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workerOperations = await _context.WorkerOperations.FindAsync(id);
            if (workerOperations != null)
            {
                _context.WorkerOperations.Remove(workerOperations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerOperationsExists(int id)
        {
            return _context.WorkerOperations.Any(e => e.WorkerId == id);
        }
    }
}

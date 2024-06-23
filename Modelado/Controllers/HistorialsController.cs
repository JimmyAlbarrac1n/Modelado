using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelado;
using Modelado.Models;

namespace Modelado.Controllers
{
    public class HistorialsController : Controller
    {
        private readonly DataContext _context;

        public HistorialsController(DataContext context)
        {
            _context = context;
        }

        // GET: Historials
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Historial.Include(h => h.Patient);
            return View(await dataContext.ToListAsync());
        }

        // GET: Historials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .Include(h => h.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // GET: Historials/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Paciente, "Id", "Id");
            return View();
        }

        // POST: Historials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,Details,DateRecorded")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Paciente, "Id", "Id", historial.PatientId);
            return View(historial);
        }

        // GET: Historials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Paciente, "Id", "Id", historial.PatientId);
            return View(historial);
        }

        // POST: Historials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,Details,DateRecorded")] Historial historial)
        {
            if (id != historial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialExists(historial.Id))
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
            ViewData["PatientId"] = new SelectList(_context.Paciente, "Id", "Id", historial.PatientId);
            return View(historial);
        }

        // GET: Historials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .Include(h => h.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // POST: Historials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historial = await _context.Historial.FindAsync(id);
            if (historial != null)
            {
                _context.Historial.Remove(historial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialExists(int id)
        {
            return _context.Historial.Any(e => e.Id == id);
        }
    }
}

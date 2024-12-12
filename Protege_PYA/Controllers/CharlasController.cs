using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Protege_PYA.Models;

namespace Protege_PYA.Controllers
{
    public class CharlasController : Controller
    {
        private readonly ProtegePyaContext _context;

        public CharlasController(ProtegePyaContext context)
        {
            _context = context;
        }

        // GET: Charlas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Charlas.ToListAsync());
        }

        // GET: Charlas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charla = await _context.Charlas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (charla == null)
            {
                return NotFound();
            }

            return View(charla);
        }

        // GET: Charlas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Charlas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaHora,LinkMeet,Asistir")] Charla charla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(charla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(charla);
        }

        // GET: Charlas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charla = await _context.Charlas.FindAsync(id);
            if (charla == null)
            {
                return NotFound();
            }
            return View(charla);
        }

        // POST: Charlas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaHora,LinkMeet,Asistir")] Charla charla)
        {
            if (id != charla.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharlaExists(charla.Id))
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
            return View(charla);
        }

        // GET: Charlas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charla = await _context.Charlas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (charla == null)
            {
                return NotFound();
            }

            return View(charla);
        }

        // POST: Charlas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charla = await _context.Charlas.FindAsync(id);
            if (charla != null)
            {
                _context.Charlas.Remove(charla);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharlaExists(int id)
        {
            return _context.Charlas.Any(e => e.Id == id);
        }
    }
}

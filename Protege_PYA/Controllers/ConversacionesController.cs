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
    public class ConversacionesController : Controller
    {
        private readonly ProtegePyaContext _context;

        public ConversacionesController(ProtegePyaContext context)
        {
            _context = context;
        }

        // GET: Conversaciones
        public async Task<IActionResult> Index()
        {
            var protegePyaContext = _context.Conversaciones.Include(c => c.Usuario1).Include(c => c.Usuario2);
            return View(await protegePyaContext.ToListAsync());
        }

        // GET: Conversaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversacione = await _context.Conversaciones
                .Include(c => c.Usuario1)
                .Include(c => c.Usuario2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conversacione == null)
            {
                return NotFound();
            }

            return View(conversacione);
        }

        // GET: Conversaciones/Create
        public IActionResult Create()
        {
            ViewData["Usuario1id"] = new SelectList(_context.Usuarios, "Id", "Id");
            ViewData["Usuario2id"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Conversaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usuario1id,Usuario2id,FechaInicio,Estado")] Conversacione conversacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conversacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Usuario1id"] = new SelectList(_context.Usuarios, "Id", "Id", conversacione.Usuario1id);
            ViewData["Usuario2id"] = new SelectList(_context.Usuarios, "Id", "Id", conversacione.Usuario2id);
            return View(conversacione);
        }

        // GET: Conversaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversacione = await _context.Conversaciones.FindAsync(id);
            if (conversacione == null)
            {
                return NotFound();
            }
            ViewData["Usuario1id"] = new SelectList(_context.Usuarios, "Id", "Id", conversacione.Usuario1id);
            ViewData["Usuario2id"] = new SelectList(_context.Usuarios, "Id", "Id", conversacione.Usuario2id);
            return View(conversacione);
        }

        // POST: Conversaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Usuario1id,Usuario2id,FechaInicio,Estado")] Conversacione conversacione)
        {
            if (id != conversacione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conversacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConversacioneExists(conversacione.Id))
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
            ViewData["Usuario1id"] = new SelectList(_context.Usuarios, "Id", "Id", conversacione.Usuario1id);
            ViewData["Usuario2id"] = new SelectList(_context.Usuarios, "Id", "Id", conversacione.Usuario2id);
            return View(conversacione);
        }

        // GET: Conversaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversacione = await _context.Conversaciones
                .Include(c => c.Usuario1)
                .Include(c => c.Usuario2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conversacione == null)
            {
                return NotFound();
            }

            return View(conversacione);
        }

        // POST: Conversaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conversacione = await _context.Conversaciones.FindAsync(id);
            if (conversacione != null)
            {
                _context.Conversaciones.Remove(conversacione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConversacioneExists(int id)
        {
            return _context.Conversaciones.Any(e => e.Id == id);
        }
    }
}

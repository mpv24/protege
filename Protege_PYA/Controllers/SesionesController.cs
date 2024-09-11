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
    public class SesionesController : Controller
    {
        private readonly ProtegePyaContext _context;

        public SesionesController(ProtegePyaContext context)
        {
            _context = context;
        }

        // GET: Sesiones
        public async Task<IActionResult> Index()
        {
            var protegePyaContext = _context.Sesiones.Include(s => s.Usuario);
            return View(await protegePyaContext.ToListAsync());
        }

        // GET: Sesiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesione = await _context.Sesiones
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesione == null)
            {
                return NotFound();
            }

            return View(sesione);
        }

        // GET: Sesiones/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Sesiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,Token,FechaInicio,FechaUltimaActividad,Activo")] Sesione sesione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sesione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", sesione.UsuarioId);
            return View(sesione);
        }

        // GET: Sesiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesione = await _context.Sesiones.FindAsync(id);
            if (sesione == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", sesione.UsuarioId);
            return View(sesione);
        }

        // POST: Sesiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,Token,FechaInicio,FechaUltimaActividad,Activo")] Sesione sesione)
        {
            if (id != sesione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sesione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesioneExists(sesione.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", sesione.UsuarioId);
            return View(sesione);
        }

        // GET: Sesiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesione = await _context.Sesiones
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesione == null)
            {
                return NotFound();
            }

            return View(sesione);
        }

        // POST: Sesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sesione = await _context.Sesiones.FindAsync(id);
            if (sesione != null)
            {
                _context.Sesiones.Remove(sesione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SesioneExists(int id)
        {
            return _context.Sesiones.Any(e => e.Id == id);
        }
    }
}

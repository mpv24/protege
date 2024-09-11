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
    public class HistoriasCuentosController : Controller
    {
        private readonly ProtegePyaContext _context;

        public HistoriasCuentosController(ProtegePyaContext context)
        {
            _context = context;
        }

        // GET: HistoriasCuentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.HistoriasCuentos.ToListAsync());
        }

        // GET: HistoriasCuentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiasCuento = await _context.HistoriasCuentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historiasCuento == null)
            {
                return NotFound();
            }

            return View(historiasCuento);
        }

        // GET: HistoriasCuentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistoriasCuentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Autor,Descripcion,Url,FormatoImagen")] HistoriasCuento historiasCuento, IFormFile imagen)
        {
            if (!string.IsNullOrEmpty(historiasCuento.Url) && !Uri.IsWellFormedUriString(historiasCuento.Url, UriKind.Absolute))
            {
                ModelState.AddModelError("Url", "La URL ingresada no es válida.");
            }

            if (ModelState.IsValid)
            {
                if (imagen != null && imagen.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imagen.CopyToAsync(memoryStream);
                        historiasCuento.Imagen = memoryStream.ToArray();
                    }

                    historiasCuento.FormatoImagen = imagen.ContentType;
                }

                _context.Add(historiasCuento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historiasCuento);
        }


        // GET: HistoriasCuentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiasCuento = await _context.HistoriasCuentos.FindAsync(id);
            if (historiasCuento == null)
            {
                return NotFound();
            }
            return View(historiasCuento);
        }

        // POST: HistoriasCuentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Autor,Descripcion,Url,FormatoImagen")] HistoriasCuento historiasCuento, IFormFile imagen)
        {
            if (id != historiasCuento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imagen != null && imagen.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await imagen.CopyToAsync(memoryStream);
                            historiasCuento.Imagen = memoryStream.ToArray();
                        }

                        historiasCuento.FormatoImagen = imagen.ContentType;
                    }

                    _context.Update(historiasCuento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriasCuentoExists(historiasCuento.Id))
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
            return View(historiasCuento);
        }

        // POST: HistoriasCuentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historiasCuento = await _context.HistoriasCuentos.FindAsync(id);
            if (historiasCuento != null)
            {
                _context.HistoriasCuentos.Remove(historiasCuento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriasCuentoExists(int id)
        {
            return _context.HistoriasCuentos.Any(e => e.Id == id);
        }
    }
}

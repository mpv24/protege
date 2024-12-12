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
    public class ProfesionalesController : Controller
    {
        private readonly ProtegePyaContext _context;

        public ProfesionalesController(ProtegePyaContext context)
        {
            _context = context;
        }

        // GET: Profesionales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesionales.ToListAsync());
        }

        // GET: Profesionales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionale = await _context.Profesionales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesionale == null)
            {
                return NotFound();
            }

            return View(profesionale);
        }

        public async Task<IActionResult> GetImage(int id)
        {
            var profesional = await _context.Profesionales.FindAsync(id);
            if (profesional == null || profesional.Imagen == null)
            {
                return NotFound();
            }

            return File(profesional.Imagen, profesional.ImagenMimeType);
        }

        // GET: Profesionales/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Profesionales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Especialidad,Informacion,UsuarioId")] Profesionale profesionale, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                if (Imagen != null && Imagen.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await Imagen.CopyToAsync(memoryStream);
                        profesionale.Imagen = memoryStream.ToArray();
                        profesionale.ImagenMimeType = Imagen.ContentType;
                    }
                }

                _context.Add(profesionale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", profesionale.UsuarioId);
            return View(profesionale);
        }

        // GET: Profesionales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionale = await _context.Profesionales.FindAsync(id);
            if (profesionale == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", profesionale.UsuarioId);
            return View(profesionale);
        }

        // POST: Profesionales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Especialidad,Informacion,UsuarioId")] Profesionale profesionale, IFormFile Imagen)
        {
            if (id != profesionale.Id)
            {
                return NotFound();
            }

            // Remover validación de la imagen
            ModelState.Remove("Imagen");

            if (ModelState.IsValid)
            {
                try
                {
                    // Buscar el profesional existente en la base de datos
                    var existingProfesionale = await _context.Profesionales.FindAsync(id);
                    if (existingProfesionale == null)
                    {
                        return NotFound();
                    }

                    // Actualiza solo los campos editables
                    existingProfesionale.Nombre = profesionale.Nombre;
                    existingProfesionale.Apellido = profesionale.Apellido;
                    existingProfesionale.Especialidad = profesionale.Especialidad;
                    existingProfesionale.Informacion = profesionale.Informacion;

                    // Si se proporciona una nueva imagen, actualízala
                    if (Imagen != null && Imagen.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await Imagen.CopyToAsync(memoryStream);
                            existingProfesionale.Imagen = memoryStream.ToArray();
                            existingProfesionale.ImagenMimeType = Imagen.ContentType;
                        }
                    }

                    // Guarda los cambios en la base de datos
                    _context.Update(existingProfesionale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionaleExists(profesionale.Id))
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

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", profesionale.UsuarioId);
            return View(profesionale);
        }

        // GET: Profesionales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionale = await _context.Profesionales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesionale == null)
            {
                return NotFound();
            }

            return View(profesionale);
        }

        // POST: Profesionales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesionale = await _context.Profesionales.FindAsync(id);
            if (profesionale != null)
            {
                _context.Profesionales.Remove(profesionale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionaleExists(int id)
        {
            return _context.Profesionales.Any(e => e.Id == id);
        }
    }
}

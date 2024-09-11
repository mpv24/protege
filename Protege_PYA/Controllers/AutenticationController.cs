using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Protege_PYA.Models;

namespace Protege_PYA.Controllers
{
    public class AutenticationController : Controller
    {
        private readonly ProtegePyaContext _context;

        public AutenticationController(ProtegePyaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Usuario1))
            {
                var user = await _context.Usuarios
                                         .Include(u => u.Rol)
                                         .SingleOrDefaultAsync(u => u.Usuario1 == usuario.Usuario1);

                if (user != null)
                {
                    if (user.Estado == true)
                    {
                        ModelState.AddModelError("", "Cuenta bloqueada. Contacte al administrador.");
                        return View();
                    }

                    if (BCrypt.Net.BCrypt.Verify(usuario.Pass, user.Pass))
                    {
                        if (user.Estado == false)
                        {
                            user.Intentos = 0; // Reinicia los intentos fallidos en caso de éxito
                            await _context.SaveChangesAsync();

                            var roleName = user.Rol?.Rol ?? "Guest"; // Asignar rol predeterminado si es nulo
                            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Usuario1),
                        new Claim(ClaimTypes.Role, roleName)
                    };
                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity));

                            var returnUrl = Request.Query["ReturnUrl"].ToString();
                            if (string.IsNullOrEmpty(returnUrl))
                            {
                                returnUrl = "/Home/Inicio"; // Redirige a la página de inicio por defecto si no hay ReturnUrl
                            }
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        user.Intentos++;
                        if (user.Intentos >= 3)
                        {
                            user.Estado = true;
                        }

                        await _context.SaveChangesAsync();
                    }
                }

                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
            }

            return View();
        }

        [HttpGet]
        public ActionResult CrearInvitado()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearInvitado(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Pass = BCrypt.Net.BCrypt.HashPassword(usuario.Pass, BCrypt.Net.BCrypt.GenerateSalt());
                usuario.Estado = false;

                var rol = await _context.Roles.SingleOrDefaultAsync(r => r.Rol == "Usuario");
                if (rol != null)
                {
                    usuario.RolId = rol.Id;
                }

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public ActionResult CrearProfesional()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearProfesional(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Pass = BCrypt.Net.BCrypt.HashPassword(usuario.Pass, BCrypt.Net.BCrypt.GenerateSalt());
                usuario.Estado = false;

                var rol = await _context.Roles.SingleOrDefaultAsync(r => r.Rol == "Profesional");
                if (rol != null)
                {
                    usuario.RolId = rol.Id;
                }

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Autentication");
        }
    }
}

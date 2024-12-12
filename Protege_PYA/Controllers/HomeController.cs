using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Protege_PYA.Models;
using System.Diagnostics;

namespace Protege_PYA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProtegePyaContext _context;

        public HomeController(ILogger<HomeController> logger, ProtegePyaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            List<Evento> eventos = _context.Eventos.ToList();
            List<object> items = new List<object>();

            foreach (Evento evento in eventos)
            {
                var item = new
                {
                    id = evento.Id,
                    title = evento.Titulo,
                    start = evento.Fecha.HasValue ? evento.Fecha.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null
                };
                items.Add(item);
            }
            ViewBag.Eventos = JsonConvert.SerializeObject(items);
            return View();
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

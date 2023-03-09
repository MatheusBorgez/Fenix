using Fenix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace Fenix.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.Include(c => c.Cidade).ToListAsync());
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewBag.Cidade = new SelectList
                (
                    _context.Cidades.AsEnumerable(),
                    "Id",
                    "Nome"
                );
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco,Bairro,Cep,Telefone")] Cliente cliente, [FromForm] int cidade)
        {
            cliente.Cidade = _context.Cidades.First(c => c.Id == cidade);
            _context.Add(cliente);
            await _context.SaveChangesAsync();                
            
            ViewBag.Cidade = new SelectList
            (
                _context.Cidades.AsEnumerable(),
                "Id",
                "Nome"
            );
            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Report
        public IActionResult Report()
        {
            var pdf = new ViewAsPdf
            {
                WkhtmlPath = "C:\\Users\\Cis\\Desktop\\TesteMatheus",
                ViewName = "Report",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                IsGrayScale = true,
                Model = _context.Clientes.Include(c => c.Cidade).OrderBy(c => c.Cidade.Nome)
            };

            return pdf;
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisJur.Models;

namespace SisJur.Controllers
{
    public class AdvController : Controller
    {
        private readonly Contexto _context;

        public AdvController(Contexto context)
        {
            _context = context;
        }

        // GET: Adv
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Advogados.Include(a => a.area);
            return View(await contexto.ToListAsync());
        }

        //get: Adv/Create
        [HttpGet]
        public IActionResult Create ()
        {
            ViewData["areaid"] = new SelectList(_context.Areas, "id", "descricao");
            return View();
        }

        //post: Adv/Create
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,cidade,estado,idade,areaid")] Advogado advogado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advogado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["areaid"] = new SelectList(_context.Areas, "id", "descricao", advogado.areaid);
            return View(advogado);
        }



    }
}

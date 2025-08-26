using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisJur.Models;

namespace SisJur.Controllers
{
    public class VarasController : Controller
    {
        private readonly Contexto _context;

        public VarasController(Contexto context)
        {
            _context = context;
        }

        // GET: Varas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Varas.Include(v => v.Advogado).Include(v => v.Processo);
            return View(await contexto.ToListAsync());
        }

        // GET: Varas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vara = await _context.Varas
                .Include(v => v.Advogado)
                .Include(v => v.Processo)
                .FirstOrDefaultAsync(m => m.id == id);
            if (vara == null)
            {
                return NotFound();
            }

            return View(vara);
        }

        // GET: Varas/Create
        public IActionResult Create()
        {
            ViewData["advogadoid"] = new SelectList(_context.Advogados, "id", "cidade");
            ViewData["processoid"] = new SelectList(_context.Processos, "id", "id");
            return View();
        }

        // POST: Varas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,processoid,advogadoid,juiz,valorcausa")] Vara vara)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vara);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["advogadoid"] = new SelectList(_context.Advogados, "id", "cidade", vara.advogadoid);
            ViewData["processoid"] = new SelectList(_context.Processos, "id", "id", vara.processoid);
            return View(vara);
        }

        // GET: Varas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vara = await _context.Varas.FindAsync(id);
            if (vara == null)
            {
                return NotFound();
            }
            ViewData["advogadoid"] = new SelectList(_context.Advogados, "id", "cidade", vara.advogadoid);
            ViewData["processoid"] = new SelectList(_context.Processos, "id", "id", vara.processoid);
            return View(vara);
        }

        // POST: Varas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,processoid,advogadoid,juiz,valorcausa")] Vara vara)
        {
            if (id != vara.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vara);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaraExists(vara.id))
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
            ViewData["advogadoid"] = new SelectList(_context.Advogados, "id", "cidade", vara.advogadoid);
            ViewData["processoid"] = new SelectList(_context.Processos, "id", "id", vara.processoid);
            return View(vara);
        }

        // GET: Varas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vara = await _context.Varas
                .Include(v => v.Advogado)
                .Include(v => v.Processo)
                .FirstOrDefaultAsync(m => m.id == id);
            if (vara == null)
            {
                return NotFound();
            }

            return View(vara);
        }

        // POST: Varas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vara = await _context.Varas.FindAsync(id);
            if (vara != null)
            {
                _context.Varas.Remove(vara);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaraExists(int id)
        {
            return _context.Varas.Any(e => e.id == id);
        }
    }
}

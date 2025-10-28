using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisJur.Models;

namespace SisJur.Controllers
{
    [Authorize]
    public class AdvogadosController : Controller
    {
        private readonly Contexto _context;

        public AdvogadosController(Contexto context)
        {
            _context = context;
        }

        // GET: Advogados
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Advogados.Include(a => a.area);
            return View(await contexto.ToListAsync());
        }

        // GET: Advogados/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advogado = await _context.Advogados
                .Include(a => a.area)
                .FirstOrDefaultAsync(m => m.id == id);
            if (advogado == null)
            {
                return NotFound();
            }

            return View(advogado);
        }

        // GET: Advogados/Create
        public IActionResult Create()
        {
            ViewData["areaid"] = new SelectList(_context.Areas, "id", "descricao");
            return View();
        }

        // POST: Advogados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Advogados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advogado = await _context.Advogados.FindAsync(id);
            if (advogado == null)
            {
                return NotFound();
            }
            ViewData["areaid"] = new SelectList(_context.Areas, "id", "descricao", advogado.areaid);
            return View(advogado);
        }

        // POST: Advogados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,cidade,estado,idade,areaid")] Advogado advogado)
        {
            if (id != advogado.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advogado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvogadoExists(advogado.id))
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
            ViewData["areaid"] = new SelectList(_context.Areas, "id", "descricao", advogado.areaid);
            return View(advogado);
        }

        // GET: Advogados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advogado = await _context.Advogados
                .Include(a => a.area)
                .FirstOrDefaultAsync(m => m.id == id);
            if (advogado == null)
            {
                return NotFound();
            }

            return View(advogado);
        }

        // POST: Advogados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advogado = await _context.Advogados.FindAsync(id);
            if (advogado != null)
            {
                _context.Advogados.Remove(advogado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvogadoExists(int id)
        {
            return _context.Advogados.Any(e => e.id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisJur.Migrations;
using SisJur.Models;
using static SisJur.Models.Processo;
using Status = SisJur.Models.Processo.Status;

namespace SisJur.Controllers
{
    public class ProcessosController : Controller
    {
        private readonly Contexto _context;

        public ProcessosController(Contexto context)
        {
            _context = context;
        }

        // GET: Processos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Processos.Include(p => p.tipoprocesso);
            return View(await contexto.ToListAsync());
        }

        // GET: Processos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processos
                .Include(p => p.tipoprocesso)
                .FirstOrDefaultAsync(m => m.id == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // GET: Processos/Create
        public IActionResult Create()
        {
            var tStatus = Enum.GetValues(typeof(Status))
                                         .Cast<Status>()
                                         .Select(e => new SelectListItem
                                         {
                                             Value = e.ToString(),
                                             Text = e.ToString()
                                         });
            ViewBag.tStatus = tStatus;


            ViewData["tipoprocessoid"] = new SelectList(_context.TipoProcessos, "id", "descricao");
            return View();
        }

        // POST: Processos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,entrada,tipoprocessoid,status")] Processo processo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tipoprocessoid"] = new SelectList(_context.TipoProcessos, "id", "descricao", processo.tipoprocessoid);
            return View(processo);
        }

        // GET: Processos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processos.FindAsync(id);
            if (processo == null)
            {
                return NotFound();
            }
            ViewData["tipoprocessoid"] = new SelectList(_context.TipoProcessos, "id", "descricao", processo.tipoprocessoid);
            return View(processo);
        }

        // POST: Processos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,entrada,tipoprocessoid,status")] Processo processo)
        {
            if (id != processo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessoExists(processo.id))
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
            ViewData["tipoprocessoid"] = new SelectList(_context.TipoProcessos, "id", "descricao", processo.tipoprocessoid);
            return View(processo);
        }

        // GET: Processos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processos
                .Include(p => p.tipoprocesso)
                .FirstOrDefaultAsync(m => m.id == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // POST: Processos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processo = await _context.Processos.FindAsync(id);
            if (processo != null)
            {
                _context.Processos.Remove(processo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessoExists(int id)
        {
            return _context.Processos.Any(e => e.id == id);
        }
    }
}

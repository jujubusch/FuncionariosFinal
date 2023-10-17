using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFuncionarios.Models;

namespace FuncionariosFinal.Controllers
{
    public class EscalaController : Controller
    {
        private readonly Contexto _context;

        public EscalaController(Contexto context)
        {
            _context = context;
        }

        // GET: Escala
        public async Task<IActionResult> Index()
        {
              return _context.Escala != null ? 
                          View(await _context.Escala.ToListAsync()) :
                          Problem("Entity set 'Contexto.Escala'  is null.");
        }

        // GET: Escala/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Escala == null)
            {
                return NotFound();
            }

            var escala = await _context.Escala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escala == null)
            {
                return NotFound();
            }

            return View(escala);
        }

        // GET: Escala/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escala/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HorarioEntrada,IntervaloSaida,IntervaloRetorno,HorarioSaida")] Escala escala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escala);
        }

        // GET: Escala/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Escala == null)
            {
                return NotFound();
            }

            var escala = await _context.Escala.FindAsync(id);
            if (escala == null)
            {
                return NotFound();
            }
            return View(escala);
        }

        // POST: Escala/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HorarioEntrada,IntervaloSaida,IntervaloRetorno,HorarioSaida")] Escala escala)
        {
            if (id != escala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscalaExists(escala.Id))
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
            return View(escala);
        }

        // GET: Escala/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Escala == null)
            {
                return NotFound();
            }

            var escala = await _context.Escala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escala == null)
            {
                return NotFound();
            }

            return View(escala);
        }

        // POST: Escala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Escala == null)
            {
                return Problem("Entity set 'Contexto.Escala'  is null.");
            }
            var escala = await _context.Escala.FindAsync(id);
            if (escala != null)
            {
                _context.Escala.Remove(escala);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscalaExists(int id)
        {
          return (_context.Escala?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

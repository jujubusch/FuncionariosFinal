using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuncionariosFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosFinal.Controllers
{
    public class PontoController : Controller
    {
        private readonly Contexto _context;

        public PontoController(Contexto context)
        {
            _context = context;
        }

        // GET: Ponto


        // GET: Ponto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ponto == null)
            {
                return NotFound();
            }

            var ponto = await _context.Ponto
                .Include(p => p.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ponto == null)
            {
                return NotFound();
            }

            return View(ponto);
        }

        // GET: Ponto/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionário, "Id", "NomeFuncionario");
            return View();
        }

        // POST: Ponto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HorarioEntrada,SaidaAlmoco,VoltaAlmoco,HorarioSaida,Data,FuncionarioId")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ponto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionário, "Id", "NomeFuncionario", ponto.FuncionarioId);
            return View(ponto);
        }

        // GET: Ponto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ponto == null)
            {
                return NotFound();
            }

            var ponto = await _context.Ponto.FindAsync(id);
            if (ponto == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionário, "Id", "NomeFuncionario", ponto.FuncionarioId);
            return View(ponto);
        }

        // POST: Ponto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HorarioEntrada,SaidaAlmoco,VoltaAlmoco,HorarioSaida,Data,FuncionarioId")] Ponto ponto)
        {
            if (id != ponto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ponto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoExists(ponto.Id))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionário, "Id", "NomeFuncionario", ponto.FuncionarioId);
            return View(ponto);
        }

        // GET: Ponto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ponto == null)
            {
                return NotFound();
            }

            var ponto = await _context.Ponto
                .Include(p => p.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ponto == null)
            {
                return NotFound();
            }

            return View(ponto);
        }

        // POST: Ponto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ponto == null)
            {
                return Problem("Entity set 'Contexto.Ponto'  is null.");
            }
            var ponto = await _context.Ponto.FindAsync(id);
            if (ponto != null)
            {
                _context.Ponto.Remove(ponto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoExists(int id)
        {
          return (_context.Ponto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

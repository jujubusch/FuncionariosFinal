﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuncionariosFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosFinal.Controllers
{
    public class CargoController : Controller
    {
        private readonly Contexto _context;

        public CargoController(Contexto context)
        {
            _context = context;
        }


        // GET: Cargo
        public async Task<IActionResult> Index(string pesquisa)
        {

            if (string.IsNullOrWhiteSpace(pesquisa))
            {
                return _context.Cargo.Include(x=> x.Escala) != null ?
                      View(await _context.Cargo.Include(x => x.Escala).ToListAsync()) :
                      Problem("Entity set 'Contexto.Produto'  is null.");
            }
            else
            {
                var pessoa =
                    _context.Cargo
                    .Include(x => x.Escala)
                    .Where(x => x.DescricaoCargo.Contains(pesquisa))
                    .OrderBy(x => x.DescricaoCargo);

                return View(pessoa);
            }

        }
      

        // GET: Cargo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cargo == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .Include(c => c.Escala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // GET: Cargo/Create
        public IActionResult Create()
        {
            ViewData["EscalaId"] = new SelectList(_context.Escala, "Id", "DescricaoHorario");
            return View();
        }

        // POST: Cargo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoCargo,SalarioCargo,EscalaId")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscalaId"] = new SelectList(_context.Escala, "Id", "DescricaoHorario", cargo.EscalaId);
            return View(cargo);
        }

        // GET: Cargo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cargo == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }
            ViewData["EscalaId"] = new SelectList(_context.Escala, "Id", "DescricaoHorario", cargo.EscalaId);
            return View(cargo);
        }

        // POST: Cargo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoCargo,SalarioCargo,EscalaId")] Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.Id))
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
            ViewData["EscalaId"] = new SelectList(_context.Escala, "Id", "EscalaId", cargo.EscalaId);
            return View(cargo);
        }

        // GET: Cargo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cargo == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .Include(c => c.Escala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // POST: Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cargo == null)
            {
                return Problem("Entity set 'Contexto.Cargo'  is null.");
            }
            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo != null)
            {
                _context.Cargo.Remove(cargo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoExists(int id)
        {
          return (_context.Cargo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

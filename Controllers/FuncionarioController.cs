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
    public class FuncionarioController : Controller
    {
        private readonly Contexto _context;

        public FuncionarioController(Contexto context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (string.IsNullOrWhiteSpace(pesquisa))
            {
                return _context.Funcionario != null ?
                    View(await _context.Funcionario.ToListAsync()) :
                    Problem("Entity set 'Contexto.Cargo'  is null.");
            }
            else
            {
                var pessoa =
                    _context.Funcionario
                    .Where(x => x.NomeFuncionario.Contains(pesquisa))
                    .OrderBy(x => x.NomeFuncionario);

                return View(pessoa);
            }
        }

        private ObjectResult View(object value)
        {
            throw new NotImplementedException();
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcionário == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionário
                .Include(f => f.Cargo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            ViewData["DescricaoCargo"] = new SelectList(_context.Cargo, "Id", "DescricaoCargo");
            ViewData["CargoId"] = new SelectList(_context.Cargo, "Id", "DescricaoCargo");
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFuncionario,CargoId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "Id", "DescricaoCargo", funcionario.CargoId);
            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcionário == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionário.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "Id", "DescricaoCargo", funcionario.CargoId);
            ViewData["DescricaoCargo"] = new SelectList(_context.Cargo, "Id", "DescricaoCargo", funcionario.CargoId);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFuncionario,CargoId")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
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
            ViewData["CargoId"] = new SelectList(_context.Cargo, "Id", "DescricaoCargo", funcionario.CargoId);
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionário == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionário
                .Include(f => f.Cargo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionário == null)
            {
                return Problem("Entity set 'Contexto.Funcionário'  is null.");
            }
            var funcionario = await _context.Funcionário.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionário.Remove(funcionario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
          return (_context.Funcionário?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

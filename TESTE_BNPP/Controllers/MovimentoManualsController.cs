using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace TESTE_BNPP.Controllers
{
    public class MovimentoManualsController : Controller
    {
        private readonly DB_BNPPContext _context;

        public MovimentoManualsController(DB_BNPPContext context)
        {
            _context = context;
        }

        // GET: MovimentoManuals
        public async Task<IActionResult> Index()
        {
            var dB_BNPPContext = _context.MovimentoManual.Include(m => m.CodCosifNavigation);
            return View(await dB_BNPPContext.ToListAsync());
        }

        // GET: MovimentoManuals/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentoManual = await _context.MovimentoManual
                .Include(m => m.CodCosifNavigation)
                .FirstOrDefaultAsync(m => m.DatMes == id);
            if (movimentoManual == null)
            {
                return NotFound();
            }

            return View(movimentoManual);
        }

        // GET: MovimentoManuals/Create
        public IActionResult Create()
        {
            ViewData["CodCosif"] = new SelectList(_context.ProdutoCosif, "CodCosif", "CodCosif");
            return View();
        }

        // POST: MovimentoManuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatMes,DatAno,NumLancamento,CodProduto,CodCosif,ValValor,DesDescricao,DatMovimento,CodUsuarios")] MovimentoManual movimentoManual)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentoManual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCosif"] = new SelectList(_context.ProdutoCosif, "CodCosif", "CodCosif", movimentoManual.CodCosif);
            return View(movimentoManual);
        }

        // GET: MovimentoManuals/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentoManual = await _context.MovimentoManual.FindAsync(id);
            if (movimentoManual == null)
            {
                return NotFound();
            }
            ViewData["CodCosif"] = new SelectList(_context.ProdutoCosif, "CodCosif", "CodCosif", movimentoManual.CodCosif);
            return View(movimentoManual);
        }

        // POST: MovimentoManuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("DatMes,DatAno,NumLancamento,CodProduto,CodCosif,ValValor,DesDescricao,DatMovimento,CodUsuarios")] MovimentoManual movimentoManual)
        {
            if (id != movimentoManual.DatMes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentoManual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentoManualExists(movimentoManual.DatMes))
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
            ViewData["CodCosif"] = new SelectList(_context.ProdutoCosif, "CodCosif", "CodCosif", movimentoManual.CodCosif);
            return View(movimentoManual);
        }

        // GET: MovimentoManuals/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentoManual = await _context.MovimentoManual
                .Include(m => m.CodCosifNavigation)
                .FirstOrDefaultAsync(m => m.DatMes == id);
            if (movimentoManual == null)
            {
                return NotFound();
            }

            return View(movimentoManual);
        }

        // POST: MovimentoManuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var movimentoManual = await _context.MovimentoManual.FindAsync(id);
            _context.MovimentoManual.Remove(movimentoManual);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentoManualExists(decimal id)
        {
            return _context.MovimentoManual.Any(e => e.DatMes == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Classes;
using Domain;

namespace TESTE_BNPP.Controllers
{
    public class ProdutoCosifsController : Controller
    {
        private readonly DB_BNPPContext _context;

        public ProdutoCosifsController(DB_BNPPContext context)
        {
            _context = context;
        }

        // GET: ProdutoCosifs
        public async Task<IActionResult> Index()
        {
            var dB_BNPPContext = _context.ProdutoCosif.Include(p => p.CodProdutoNavigation);
            return View(await dB_BNPPContext.ToListAsync());
        }

        // GET: ProdutoCosifs/Create
        public IActionResult Create()
        {
            ViewData["CodProduto"] = new SelectList(_context.Produto, "CodProduto", "CodProduto");
            return View();
        }

        // POST: ProdutoCosifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodProduto,CodCosif,CodClassificacao,StaStatus")] ProdutoCosif produtoCosif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoCosif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodProduto"] = new SelectList(_context.Produto, "CodProduto", "CodProduto", produtoCosif.CodProduto);
            return View(produtoCosif);
        }

        // GET: ProdutoCosifs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoCosif = await _context.ProdutoCosif.FindAsync(id);
            if (produtoCosif == null)
            {
                return NotFound();
            }
            ViewData["CodProduto"] = new SelectList(_context.Produto, "CodProduto", "CodProduto", produtoCosif.CodProduto);
            return View(produtoCosif);
        }

        // POST: ProdutoCosifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodProduto,CodCosif,CodClassificacao,StaStatus")] ProdutoCosif produtoCosif)
        {
            if (id != produtoCosif.CodCosif)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoCosif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoCosifExists(produtoCosif.CodCosif))
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
            ViewData["CodProduto"] = new SelectList(_context.Produto, "CodProduto", "CodProduto", produtoCosif.CodProduto);
            return View(produtoCosif);
        }

        // GET: ProdutoCosifs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoCosif = await _context.ProdutoCosif
                .Include(p => p.CodProdutoNavigation)
                .FirstOrDefaultAsync(m => m.CodCosif == id);
            if (produtoCosif == null)
            {
                return NotFound();
            }

            return View(produtoCosif);
        }

        // POST: ProdutoCosifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var produtoCosif = await _context.ProdutoCosif.FindAsync(id);
            _context.ProdutoCosif.Remove(produtoCosif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoCosifExists(string id)
        {
            return _context.ProdutoCosif.Any(e => e.CodCosif == id);
        }
    }
}

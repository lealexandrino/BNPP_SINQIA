using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Classes;
using Domain;

namespace TESTE_BNPP.Controllers
{
    public class MovimentosManuaisController : Controller
    {
        // GET: MovimentoManuals
        public async Task<IActionResult> Index()
        {
            MovimentoManualDAO model = new MovimentoManualDAO();
            return View(model.ListaMovimentos());
        }

        // GET: MovimentosManuais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovimentosManuais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovimentoManual movimentoManual)
        {
            if (ModelState.IsValid)
            {
                MovimentoManualDAO model = new MovimentoManualDAO();
                model.InsereMovimento(movimentoManual);
                return RedirectToAction(nameof(Index));
            }
            return View(movimentoManual);
        }

        // GET: MovimentoManuals/Edit/5
        public async Task<IActionResult> Edit(string codProduto, string codCosif)
        {
            if (codProduto == null || codCosif == null)
            {
                return NotFound();
            }

            MovimentoManualDAO model = new MovimentoManualDAO();
            var movimentoManual = model.ObterMovimento(codProduto, codCosif);
            if (movimentoManual == null)
            {
                return NotFound();
            }
            //ViewData["CodCosif"] = new SelectList(_context.ProdutoCosif, "CodCosif", "CodCosif", movimentoManual.CodCosif);
            return View(movimentoManual);
        }

        // POST: MovimentoManuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string codProduto, string codCosif, MovimentoManual movimentoManual)
        {
            if (codProduto != movimentoManual.CodProduto || codCosif != movimentoManual.CodCosif)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                MovimentoManualDAO model = new MovimentoManualDAO();
                try
                {
                    model.AlteraMovimento(movimentoManual);
                }
                catch (Exception ex)
                {
                    if (model.ObterMovimento(movimentoManual.CodProduto, movimentoManual.CodCosif) == null)
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
            //ViewData["CodCosif"] = new SelectList(_context.ProdutoCosif, "CodCosif", "CodCosif", movimentoManual.CodCosif);
            return View(movimentoManual);
        }

        // GET: MovimentoManuals/Delete/5
        public async Task<IActionResult> Delete(string codProduto, string codCosif)
        {
            MovimentoManualDAO model = new MovimentoManualDAO();
            var movimentoManual = model.ObterMovimento(codProduto, codCosif);
            if (movimentoManual == null)
            {
                return NotFound();
            }

            return View(movimentoManual);
        }

        // POST: MovimentoManuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string codProduto, string codCosif)
        {
            MovimentoManualDAO model = new MovimentoManualDAO();
            model.DeletaMovimento(codProduto, codCosif);

            return RedirectToAction(nameof(Index));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Classes;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Linq;

namespace TESTE_BNPP.Controllers
{
    public class MovimentosManuaisController : Controller
    {
        // GET: MovimentoManuals
        public async Task<IActionResult> Index()
        {
            MovimentoManualDAO model = new MovimentoManualDAO();
            return View(model.ListaMovimentosJoin());
        }

        // GET: MovimentosManuais/Create
        public IActionResult Create()
        {
            ProdutosDAO modelProduto = new ProdutosDAO();
            var produtos = modelProduto.ListaProdutos();
            ViewData["CodProduto"] = new SelectList(modelProduto.ListaProdutos(), "CodProduto", "DesProduto");

            ProdutoCosifsDAO modelProdutoCosifs = new ProdutoCosifsDAO();
            var cosifs = modelProdutoCosifs.ListaCosifsProduto(produtos.FirstOrDefault().CodProduto);
            ViewData["CodCosif"] = new SelectList(cosifs, "CodCosif", "CodCosif");
           
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
                if (movimentoManual.CodCosif != null)
                {
                    MovimentoManualDAO model = new MovimentoManualDAO();
                    if (model.ObterMovimento(movimentoManual.CodProduto, movimentoManual.CodCosif, movimentoManual.DatMes, movimentoManual.DatAno, movimentoManual.NumLancamento) == null)
                    {
                        model.InsereMovimento(movimentoManual);
                    }
                    return RedirectToAction(nameof(Index));
                }
            }

            ProdutosDAO modelProduto = new ProdutosDAO();
            var produtos = modelProduto.ListaProdutos();
            ViewData["CodProduto"] = new SelectList(modelProduto.ListaProdutos(), "CodProduto", "DesProduto");

            ProdutoCosifsDAO modelProdutoCosifs = new ProdutoCosifsDAO();
            var cosifs = modelProdutoCosifs.ListaCosifsProduto(produtos.FirstOrDefault().CodProduto);
            ViewData["CodCosif"] = new SelectList(cosifs, "CodCosif", "CodCosif");

            return View(movimentoManual);
        }

        // GET: MovimentoManuals/Edit/5
        public async Task<IActionResult> Edit(string codProduto, string codCosif, decimal mes, decimal ano, decimal numeroLancamento)
        {
            if (codProduto == null || codCosif == null)
            {
                return NotFound();
            }

            MovimentoManualDAO model = new MovimentoManualDAO();
            var movimentoManual = model.ObterMovimento(codProduto, codCosif, mes, ano, numeroLancamento);
            if (movimentoManual == null)
            {
                return NotFound();
            }

            ProdutosDAO modelProduto = new ProdutosDAO();
            var produtos = modelProduto.ListaProdutos();
            ViewData["CodProduto"] = new SelectList(modelProduto.ListaProdutos(), "CodProduto", "DesProduto");

            ProdutoCosifsDAO modelProdutoCosifs = new ProdutoCosifsDAO();
            var cosifs = modelProdutoCosifs.ListaCosifsProduto(produtos.FirstOrDefault().CodProduto);
            ViewData["CodCosif"] = new SelectList(cosifs, "CodCosif", "CodCosif");

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
                    if (model.ObterMovimento(movimentoManual.CodProduto, movimentoManual.CodCosif, movimentoManual.DatMes, movimentoManual.DatAno, movimentoManual.NumLancamento) == null)
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

            ProdutosDAO modelProduto = new ProdutosDAO();
            var produtos = modelProduto.ListaProdutos();
            ViewData["CodProduto"] = new SelectList(modelProduto.ListaProdutos(), "CodProduto", "DesProduto");

            ProdutoCosifsDAO modelProdutoCosifs = new ProdutoCosifsDAO();
            var cosifs = modelProdutoCosifs.ListaCosifsProduto(produtos.FirstOrDefault().CodProduto);
            ViewData["CodCosif"] = new SelectList(cosifs, "CodCosif", "CodCosif");

            return View(movimentoManual);
        }

        // GET: MovimentoManuals/Delete/5
        public async Task<IActionResult> Delete(string codProduto, string codCosif, decimal mes, decimal ano, decimal numeroLancamento)
        {
            if (codProduto == null || codCosif == null)
            {
                return NotFound();
            }

            MovimentoManualDAO model = new MovimentoManualDAO();
            var movimentoManual = model.ObterMovimento(codProduto, codCosif, mes, ano, numeroLancamento);
            if (movimentoManual == null)
            {
                return NotFound();
            }

            return View(movimentoManual);
        }

        // POST: MovimentoManuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(MovimentoManual movimentoManual)
        {
            MovimentoManualDAO model = new MovimentoManualDAO();
            model.DeletaMovimento(movimentoManual.CodProduto, movimentoManual.CodCosif, movimentoManual.DatMes, movimentoManual.DatAno, movimentoManual.NumLancamento);

            return RedirectToAction(nameof(Index));
        }

        #region Json
        [HttpPost]
        public JsonResult TrazCosifs(string codProduto)
        {
            ProdutoCosifsDAO modelProdutoCosifs = new ProdutoCosifsDAO();
            var cosifs = modelProdutoCosifs.ListaCosifsProduto(codProduto);

            return Json(cosifs);
        }
        #endregion
    }
}

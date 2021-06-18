using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Classes;
using Domain;

namespace TESTE_BNPP.Controllers
{
    public class ProdutoCosifsController : Controller
    {
        // GET: ProdutoCosifs
        public async Task<IActionResult> Index()
        {
            ProdutoCosifsDAO model = new ProdutoCosifsDAO();
            return View(model.ListaProdutosCosifs());
        }

        // GET: ProdutoCosifs/Create
        public IActionResult Create()
        {
            ProdutosDAO modelProduto = new ProdutosDAO();
            ViewData["CodProduto"] = new SelectList(modelProduto.ListaProdutos(), "CodProduto", "DesProduto");

            return View();
        }

        // POST: ProdutoCosifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoCosif produtoCosif)
        {
            if (ModelState.IsValid)
            {
                ProdutoCosifsDAO model = new ProdutoCosifsDAO();
                if (model.ObterProdutoCosif(produtoCosif.CodProduto, produtoCosif.CodCosif) == null)
                {
                    model.InsereProdutoCosif(produtoCosif);
                }
                return RedirectToAction(nameof(Index));
            }

            ProdutosDAO modelProduto = new ProdutosDAO();
            ViewData["CodProduto"] = new SelectList(modelProduto.ListaProdutos(), "CodProduto", "DesProduto");
            return View(produtoCosif);
        }

        // GET: ProdutoCosifs/Edit/5
        public async Task<IActionResult> Edit(string codProduto, string codCosif)
        {
            if (codProduto == null || codCosif == null)
            {
                return NotFound();
            }

            ProdutoCosifsDAO model = new ProdutoCosifsDAO();
            var produtoCosif = model.ObterProdutoCosif(codProduto, codCosif);
            if (produtoCosif == null)
            {
                return NotFound();
            }
            ProdutosDAO modelProduto = new ProdutosDAO();
            ViewData["CodProduto"] = new SelectList(modelProduto.ListaProdutos(), "CodProduto", "DesProduto");
            return View(produtoCosif);
        }

        // POST: ProdutoCosifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string codProduto, string codCosif, ProdutoCosif produtoCosif)
        {
            if (codProduto != produtoCosif.CodProduto || codCosif != produtoCosif.CodCosif)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ProdutoCosifsDAO model = new ProdutoCosifsDAO();
                try
                {
                    model.AlteraProdutoCosif(produtoCosif);
                }
                catch (Exception ex)
                {
                    if (model.ObterProdutoCosif(produtoCosif.CodProduto, produtoCosif.CodCosif) == null)
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
            ViewData["CodProduto"] = new SelectList(modelProduto.ListaProdutos(), "CodProduto", "DesProduto");
            return View(produtoCosif);
        }

        // GET: ProdutoCosifs/Delete/5
        public async Task<IActionResult> Delete(string codProduto, string codCosif)
        {
            if (codProduto == null || codCosif == null)
            {
                return NotFound();
            }

            ProdutoCosifsDAO model = new ProdutoCosifsDAO();
            var produtoCosif = model.ObterProdutoCosif(codProduto, codCosif);
            if (produtoCosif == null)
            {
                return NotFound();
            }

            return View(produtoCosif);
        }

        // POST: ProdutoCosifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ProdutoCosif produtoCosif)
        {
            try
            {

                ProdutoCosifsDAO model = new ProdutoCosifsDAO();
                model.DeletaProdutoCosif(produtoCosif.CodProduto, produtoCosif.CodCosif);
            }
            catch (Exception)
            {
                //Pode ocorrer erro caso algum produto cosif esteja sendo usado no movimento manual
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

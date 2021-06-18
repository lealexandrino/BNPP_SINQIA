using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Classes;
using Domain;

namespace TESTE_BNPP.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            ProdutosDAO model = new ProdutosDAO();
            return View(model.ListaProdutos());
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                ProdutosDAO model = new ProdutosDAO();
                if (model.ObterProduto(produto.CodProduto) == null)
                {
                    model.InsereProduto(produto);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(string codProduto)
        {
            if (codProduto == null)
            {
                return NotFound();
            }

            ProdutosDAO model = new ProdutosDAO();
            var produto = model.ObterProduto(codProduto);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string codProduto, Produto produto)
        {
            if (codProduto != produto.CodProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ProdutosDAO model = new ProdutosDAO();
                try
                {
                    model.AlteraProduto(produto);
                }
                catch (Exception ex)
                {
                    if (model.ObterProduto(produto.CodProduto) == null)
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

            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(string codProduto)
        {
            if (codProduto == null)
            {
                return NotFound();
            }

            ProdutosDAO model = new ProdutosDAO();
            var produto = model.ObterProduto(codProduto);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string codProduto)
        {
            ProdutosDAO model = new ProdutosDAO();
            model.DeletaProduto(codProduto);
            return RedirectToAction(nameof(Index));
        }
    }
}

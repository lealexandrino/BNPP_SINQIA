using Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Repository.Classes
{
    public class ProdutosDAO
    {
        private DB_BNPPContext _context = new DB_BNPPContext();

        public List<Produto> ListaProdutos()
        {
            try
            {

                return _context.Produto.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Produto ObterProduto(string codProduto)
        {
            return _context.Produto.Where(p => p.CodProduto == codProduto.Trim()).FirstOrDefault();
        }

        public void InsereProduto(Produto _produto)
        {
            _context.Produto.Add(_produto);
            _context.SaveChanges();
        }

        public void AlteraProduto(Produto _produto)
        {
            _context.Produto.Update(_produto);
            _context.SaveChanges();
        }

        public void DeletaProduto(string codProduto)
        {
            _context.Produto.Remove(ObterProduto(codProduto));
            _context.SaveChanges();
        }
    }
}

using Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Repository.Classes
{
    public class ProdutoCosifsDAO
    {
        private DB_BNPPContext _context = new DB_BNPPContext();

        public List<ProdutoCosif> ListaProdutosCosifs()
        {
            try
            {

                return _context.ProdutoCosif.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ProdutoCosif> ListaCosifsProduto(string codProduto)
        {
            try
            {

                return _context.ProdutoCosif.Where(p => p.CodProduto == codProduto.Trim()).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ProdutoCosif ObterProdutoCosif(string codProduto, string codCosif)
        {
            return _context.ProdutoCosif.Where(p => p.CodProduto == codProduto.Trim() && p.CodCosif == codCosif.Trim()).FirstOrDefault();
        }


        public void InsereProdutoCosif(ProdutoCosif _produtoCosif)
        {
            _context.ProdutoCosif.Add(_produtoCosif);
            _context.SaveChanges();
        }

        public void AlteraProdutoCosif(ProdutoCosif _produtoCosif)
        {
            _context.ProdutoCosif.Update(_produtoCosif);
            _context.SaveChanges();
        }

        public void DeletaProdutoCosif(string codProduto, string codCosif)
        {
            _context.ProdutoCosif.Remove(ObterProdutoCosif(codProduto, codCosif));
            _context.SaveChanges();
        }
    }
}

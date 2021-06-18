using Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Repository.Classes
{
    public class MovimentoManualDAO
    {
        private DB_BNPPContext _context = new DB_BNPPContext();

        public List<MovimentoManual> ListaMovimentos()
        {
            try
            {

                return _context.MovimentoManual.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public MovimentoManual ObterMovimento(string codProduto, string codCosif)
        {
            return _context.MovimentoManual.Where(p => p.CodProduto == codProduto.Trim() && p.CodCosif == codCosif.Trim()).FirstOrDefault();
        }

        public void InsereMovimento(MovimentoManual _movimentoManual)
        {
            _context.MovimentoManual.Add(_movimentoManual);
            _context.SaveChanges();
        }

        public void AlteraMovimento(MovimentoManual _movimentoManual)
        {
            _context.MovimentoManual.Update(_movimentoManual);
            _context.SaveChanges();
        }

        public void DeletaMovimento(string codProduto, string codCosif)
        {
            _context.MovimentoManual.Remove(ObterMovimento(codProduto, codCosif));
            _context.SaveChanges();
        }
    }
}

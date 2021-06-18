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

        public List<MovimentoManual> ListaMovimentosJoin()
        {
            try
            {
                return (from m in _context.MovimentoManual
                            join p in _context.Produto on m.CodProduto equals p.CodProduto
                            select new MovimentoManual
                            {
                                CodCosif = m.CodCosif,
                                CodProduto = m.CodCosif,
                                DatAno = m.DatAno,
                                DatMes = m.DatMes,
                                DatMovimento = m.DatMovimento,
                                DesDescricao = m.DesDescricao,
                                NumLancamento = m.NumLancamento,
                                ValValor = m.ValValor,
                                DescricaoProduto = p.DesProduto
                            }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public MovimentoManual ObterMovimento(string codProduto, string codCosif, decimal mes, decimal ano, decimal numeroLancamento)
        {
            return _context.MovimentoManual.Where(p => p.CodProduto == codProduto.Trim() 
                                                    && p.CodCosif == codCosif.Trim()
                                                    && p.DatMes == mes
                                                    && p.DatAno == ano
                                                    && p.NumLancamento == numeroLancamento).FirstOrDefault();
        }

        public void InsereMovimento(MovimentoManual _movimentoManual)
        {
            _movimentoManual.NumLancamento = ListaMovimentos().LastOrDefault().NumLancamento + 1;
            _movimentoManual.CodUsuarios = "Teste";
            _movimentoManual.DatMovimento = DateTime.Now;

            _context.MovimentoManual.Add(_movimentoManual);
            _context.SaveChanges();
        }

        public void AlteraMovimento(MovimentoManual _movimentoManual)
        {
            try
            {
                _movimentoManual.CodUsuarios = "Teste";
                _context.MovimentoManual.Update(_movimentoManual);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void DeletaMovimento(string codProduto, string codCosif, decimal mes, decimal ano, decimal numeroLancamento)
        {
            _context.MovimentoManual.Remove(ObterMovimento(codProduto, codCosif, mes, ano, numeroLancamento));
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class ProdutoCosif
    {
        public ProdutoCosif()
        {
            MovimentoManual = new HashSet<MovimentoManual>();
        }

        public string CodProduto { get; set; }
        public string CodCosif { get; set; }
        public string CodClassificacao { get; set; }
        public string StaStatus { get; set; }

        public Produto CodProdutoNavigation { get; set; }
        public ICollection<MovimentoManual> MovimentoManual { get; set; }
    }
}

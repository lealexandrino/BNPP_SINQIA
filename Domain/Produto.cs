using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutoCosif = new HashSet<ProdutoCosif>();
        }

        public string CodProduto { get; set; }
        public string DesProduto { get; set; }
        public string StaStatus { get; set; }

        public ICollection<ProdutoCosif> ProdutoCosif { get; set; }
    }
}

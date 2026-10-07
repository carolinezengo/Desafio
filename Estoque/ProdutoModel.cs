using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTarget.Estoque
{
    public class ProdutoModel
    {
         public int CodigoProduto { get; set; }
        public string? DescricaoProduto { get; set; }
        public MovimentacaoEstoque? MovimentacaoEstoque  { get; set; }

        public int Estoque { get; set; }
    }
}
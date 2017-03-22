using BitFour.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitFour.LojaVirtual.Web.Models
{
    public class ProdutosViewModel
    {
        //essa é uma classe que vai representar itens do dominio 

        public IEnumerable<Produto> Produtos { get; set; }
        public Paginacao Paginacao { get; set; }
        public string CategoriaAtual { get; set; }
        
  

    }
}
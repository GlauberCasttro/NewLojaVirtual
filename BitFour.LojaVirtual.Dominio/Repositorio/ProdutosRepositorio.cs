using BitFour.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitFour.LojaVirtual.Dominio.Repositorio
{
     public class ProdutosRepositorio
    {
        //cria uma variavel para referencia o entity 
        private readonly EfDbContext _context = new EfDbContext();


        public IEnumerable<Produto> Produtos
        {
            get
            {
                return _context.Produtos;
            }
        }    


        
    }
}

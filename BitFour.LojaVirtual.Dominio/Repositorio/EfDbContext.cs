using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using BitFour.LojaVirtual.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BitFour.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        //precisa falar qual que vai ser o mapeamento, no momento vai mapear a classe produto que foi criada
        //entao vai criar um DbSet que representa uma colecao das entidades no context
        public DbSet<Produto> Produtos { get; set; }


        //configuraçao de sistema removendo a pluralidade do entity(ex: computadores,essa configuraçao se adequa para computador)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
        }

   
    }
}
                   
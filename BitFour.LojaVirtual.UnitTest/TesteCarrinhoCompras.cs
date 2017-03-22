using BitFour.LojaVirtual.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace BitFour.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        ////testar adicionar itens ao carrinho
        [TestMethod]
        public void AdcionarAoCarrinho()
        {

            //Arrange, criaçao dos produtos
            Produto prod1 = new Produto()
            {
                produtoId = 1,
                Nome = "TEste 1"
            };

            Produto prod2 = new Produto()
            {
                produtoId = 2,
                Nome = "TEste 2"
            };

            //Arrange 

            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 2);
            carrinho.AdcionarItem(prod2, 3);


            //act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();


            ////Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, prod1);
            Assert.AreEqual(itens[1].Produto, prod2);


        }

        [TestMethod]
        public void AdicionarProdutoExisteParaCarrinho()
        {
            Produto prod1 = new Produto()
            {
                produtoId = 1,
                Nome = "TEste 1"
            };

            Produto prod2 = new Produto()
            {
                produtoId = 2,
                Nome = "TEste 2"
            };

          

            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 2);
            carrinho.AdcionarItem(prod2, 3);
            carrinho.AdcionarItem(prod1, 10);





            ItemCarrinho[] result = carrinho.ItensCarrinho
                .OrderBy(c => c.Produto.produtoId).ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Quantidade,12);
            Assert.AreEqual(result[1].Quantidade,3);



        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {

            Produto prod1 = new Produto()
            {
                produtoId = 1,
                Nome = "TEste 1"
            };

            Produto prod2 = new Produto()
            {
                produtoId = 2,
                Nome = "TEste 2"
            };




            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 2);
            carrinho.AdcionarItem(prod2, 3);
            carrinho.AdcionarItem(prod1, 10);

            carrinho.RemoverItem(prod2);

            Assert.AreEqual(carrinho.ItensCarrinho.Where(c=> c.Produto == prod2).Count(),0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(),1);


        }

        [TestMethod]
        public void calcularValorTotal()
        {

            Produto prod1 = new Produto()
            {
                produtoId = 1,
                Nome = "TEste 1",
                Preco = 100M
            };

            Produto prod2 = new Produto()
            {
                produtoId = 2,
                Nome = "TEste 2",
                Preco = 100M
            };




            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 1);
            carrinho.AdcionarItem(prod2, 1);
            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado,200M);
          
            
       


        }

        [TestMethod]
        public void LimparItensCarrinho()
        {

            Produto prod1 = new Produto()
            {
                produtoId = 1,
                Nome = "TEste 1",
                Preco = 100M
            };

            Produto prod2 = new Produto()
            {
                produtoId = 2,
                Nome = "TEste 2",
                Preco = 100M
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdcionarItem(prod1, 1);
            carrinho.AdcionarItem(prod2, 1);

            carrinho.LimparCarrinho();
            Assert.AreEqual(carrinho.ItensCarrinho.Count(),0);
            
        }


    }

   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitFour.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {

        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        //obrigatoriamente irá precisar dos seguintes metodos...
        //adcionar
        public void AdcionarItem(Produto produto, int quantidade)
        {

                                                   //esse metodo retorna o primeiro elemento da sequencia 
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.produtoId == produto.produtoId);
            if (item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho {
                    Produto= produto,
                    Quantidade = quantidade
                });
            }
            else{
                item.Quantidade += quantidade;
            }
        }
              


        //remover 
        public void RemoverItem(Produto produto)
        {
                             //esse metodo remove todos os elementos 
            _itemCarrinho.RemoveAll(l => l.Produto.produtoId == produto.produtoId);
        }
           
        
 
        //obter o valor total 
        public decimal ObterValorTotal()
        {
                                    //esse metodo soma os valores 
            return _itemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }




        //limpar o carrinho 
        public void LimparCarrinho()
        {
            //limpa o carrinho metodo clear                                                                                                                                                                                                                                                                                                                     
            _itemCarrinho.Clear();

        }



        //obtem todos os itens do carrinho 
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itemCarrinho; }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}

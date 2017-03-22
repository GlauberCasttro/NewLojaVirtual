using BitFour.LojaVirtual.Dominio.Entidades;

namespace BitFour.LojaVirtual.Web.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }
        public string ReturnUrl { get; set; }
    }
}
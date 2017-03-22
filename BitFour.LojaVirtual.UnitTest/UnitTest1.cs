using BitFour.LojaVirtual.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Web.Mvc;
using BitFour.LojaVirtual.Web.HtmlHelpers;






namespace BitFour.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestBitFour
    {

        //operador Take é usado para selecionar os primeiros n objetos de uma coleção 
        [TestMethod]
        public void Take()
        {
            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resultado = from num in numeros.Take(2) select num;
            int[] teste = { 5, 4 };
            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        //O operador Skip ignora os primeiros n objetos de uma coleção 
        [TestMethod]
        public void Skip()
        {
            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var resultado = from num in numeros.Take(5).Skip(2) select num;

            int[] teste = { 1, 3, 9 };
            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }


        [TestMethod]
        public void TestarPaginacaoFuncionando()
        {

            //para fazer o teste, voce precisa preparar o metodo a ser testado, estudar a classe e os metodos que irá testar
            //esse teste verifica se a paginaçao esta funcionando corretamente

            HtmlHelper html = null;


            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };
            Func<int, string> paginaUrl = i => "Pagina" + i;
            //testando em AAA
            //esse resultado é o act 
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //assert 
            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default"" btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
                );





        }

    }
}

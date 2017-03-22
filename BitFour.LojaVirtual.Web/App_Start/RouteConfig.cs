using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BitFour.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapMvcAttributeRoutes();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //1 -rota inical da busca de produtos todas as  categorias
            routes.MapRoute(null, "", new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null, pagina = 1 });
            //--------------------------------------------------------------------------------------------------------------------





            //segunda rota  lista a pagina 
            routes.MapRoute(null, "Pagina{pagina}", new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null }, new { pagina = @"\d+" });

            //----------------------------------------------------------------------------------------------------------------------------------------------





            //terceira rota somente a os produtos da categoria 
            routes.MapRoute(null, "{categoria}", new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 });

            //----------------------------------------------------------------------------------------------------------






            //trás todas as paginas da categoria
            routes.MapRoute(null, "{categoria}/Pagina{pagina}", new { controller = "Vitrine", action = "ListaProdutos" }, new { pagina = @"\d+" });

            //-------------------------------------------------------------------------------------------------------------------------------






            //criando Url amigavel de rotaPagina
            routes.MapRoute(name: null, url: "Pagina{pagina}", defaults: new { controller = "Vitrine", action = "ListaProdutos" });



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index    ", id = UrlParameter.Optional }
            );

            routes.MapRoute(null, "{controller}/{action}");


        }
    }
}

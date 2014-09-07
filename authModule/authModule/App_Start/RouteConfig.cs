using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(
                name: "api",
                url: "api/{controller}/{action}/{id}",
                defaults: new {  action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{a}/{b}/{c}/{d}/{e}/{f}",
                defaults: new { controller = "UI",
                    action = "Index",
                                a = UrlParameter.Optional,
                                b = UrlParameter.Optional,
                                c = UrlParameter.Optional,
                                d = UrlParameter.Optional,
                                e = UrlParameter.Optional,
                                f = UrlParameter.Optional,
                                g = UrlParameter.Optional,
                                h = UrlParameter.Optional,
                                i = UrlParameter.Optional,
                                j = UrlParameter.Optional,
                                k = UrlParameter.Optional,
                                l = UrlParameter.Optional
                }
            );
           
        }
    }
}
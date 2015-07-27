using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SwcLmsMastery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
              name: "Dashboard",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Dashboard", id = UrlParameter.Optional }
              );


            routes.MapRoute(
                name: "Account",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Account", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                 name: "Admin",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
    );
            routes.MapRoute(
                 name: "Teacher",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Teacher", action = "Index", id = UrlParameter.Optional }
    );
            routes.MapRoute(
              name: "Courses",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Courses", action = "Index", id = UrlParameter.Optional }
 );
        }
    }
}

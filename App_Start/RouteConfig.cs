using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace figYureD.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapPageRoute(
                "LoginPage", 
                "login",
                "~/Views/Auth/Login.aspx"
                );

            routes.MapPageRoute(
                "RegisterPage",
                "register",
                "~/Views/Auth/Register.aspx"
                );
        }
    }
}
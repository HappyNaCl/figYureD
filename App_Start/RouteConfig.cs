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

            routes.MapPageRoute(
                "AdminDashboard",
                "admin/dashboard",
                "~/Views/Admin/AdminDashboard.aspx"
                );

            routes.MapPageRoute(
                "AddProductPage",
                "admin/products",
                "~/Views/Admin/AdminProduct.aspx"
                );

            routes.MapPageRoute(
                "EditProductPage",
                "admin/products/{id}",
                "~/Views/Admin/AdminEditProduct.aspx"
                );

            routes.MapPageRoute(
                "AddManufacturerPage",
                "admin/manufacturer",
                "~/Views/Admin/AdminManufacturer.aspx"
                );

            routes.MapPageRoute(
                "EditManufacturerPage",
                "admin/manufacturer/{id}",
                "~/Views/Admin/AdminEditManufacturer.aspx"
                );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLNX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //enabling attribute routing
            // routes.MapMvcAttributeRoutes();

           // Login
            routes.MapRoute(
                name: "Dang nhap",
                url: "dang-nhap",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );

            // Signin
            routes.MapRoute(
                name: "Dang ky",
                url: "dang-ky",
                defaults: new { controller = "Login", action = "Signin", id = UrlParameter.Optional }
            );

            // Logout
            routes.MapRoute(
                name: "Dang xuat",
                url: "dang-xuat",
                defaults: new { controller = "Login", action = "Logout", id = UrlParameter.Optional }
            );

            //MuaVe/Lich
            routes.MapRoute(
               name: "Mua ve",
               url: "danh-sach-ve",
               defaults: new { controller = "MuaVe", action = "Lich", id = UrlParameter.Optional }
           );

            //MuaVe/DatVe/id 
            routes.MapRoute(
               name: "Dat ve",
               url: "dat-ve/{id}",
               defaults: new { controller = "MuaVe", action = "DatVe", id = UrlParameter.Optional }
           );

            //MuaVe/ChiTietVe
            routes.MapRoute(
               name: "Chi tiet ve",
               url: "chi-tiet-ve",
               defaults: new { controller = "MuaVe", action = "ChiTietVe", id = UrlParameter.Optional }
           );

            //MuaVe/Successful
            routes.MapRoute(
               name: "Successful",
               url: "xac-nhan-thanh-cong",
               defaults: new { controller = "MuaVe", action = "Successful", id = UrlParameter.Optional }
           );

            // vé của tôi
            routes.MapRoute(
                name: "Ve cua toi",
                url: "ve-cua-toi",
                defaults: new { controller = "MyBooking", action = "Index", id = UrlParameter.Optional }
            );

            // default in the end
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MuaVe", action = "Index", id = UrlParameter.Optional }, 
                namespaces: new[] { "QLNX.Areas.Admin.Controllers" }
            );
        }
    }
}

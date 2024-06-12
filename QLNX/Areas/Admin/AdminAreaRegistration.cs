using System.Web.Mvc;

namespace QLNX.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            // Login
            context.MapRoute(
                "Admin Login",
                "Admin/dang-nhap",
                new { action = "Login", controller = "Account", id = UrlParameter.Optional }
            );

            // Logout
            context.MapRoute(
                "Admin Logout",
                "Admin/dang-xuat",
                new { action = "Logout", controller = "Account", id = UrlParameter.Optional }
            );

            
            //lich
            context.MapRoute(
                "Lich",
                "Admin/quan-ly-lich",
                new { action = "Index", controller = "Lich", id = UrlParameter.Optional }
            );

            //Nhan vien
            context.MapRoute(
                "Nhan vien",
                "Admin/quan-ly-nhan-vien",
                new { action = "Index", controller = "Employee", id = UrlParameter.Optional }
            );

            //Don hang
            context.MapRoute(
                "Don hang",
                "Admin/don-hang",
                new { action = "Index", controller = "DonHang", id = UrlParameter.Optional }
            );

            //Xe
            context.MapRoute(
                "Xe",
                "Admin/quan-ly-xe",
                new { action = "Index", controller = "Xe", id = UrlParameter.Optional }
            );


            //ghế
            context.MapRoute(
                "Ghe",
                "Admin/chi-tiet-ghe",
                new { action = "Index", controller = "Ghe", id = UrlParameter.Optional }
            );


            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Login", controller = "Account", id = UrlParameter.Optional }
            );
        }
    }
}
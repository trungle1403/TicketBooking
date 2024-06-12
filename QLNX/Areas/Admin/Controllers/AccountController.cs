using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLNX.Areas.Admin.Models;
using System.Data.SqlClient;
using QLNX.DB;
using QLNX.Common;

namespace QLNX.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand sc = new SqlCommand();
        SqlDataReader dr;
        NHANVIEN nv = new NHANVIEN();
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountModel acc)
        {
            //Cách 1
            //if (ModelState.IsValid)
            //{
            //    connectionString();
            //    conn.Open();
            //    sc.Connection = conn;
            //    sc.CommandText = "select * from NHANVIEN where CMND ='" + acc.UserName + "' and MATKHAUNV='" + acc.PassWord + "'";
            //    dr = sc.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        return RedirectToAction("DanhSachNhanVien", "NhanVien");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Đăng nhập không thành công");

            //    }
            //}
            //return View("Login");

            //Cách 2
            if (ModelState.IsValid)
            {
                var obj = db.NHANVIEN.Where(x => x.CMND == acc.UserName && x.MATKHAUNV == acc.PassWord).FirstOrDefault();
                if(obj != null)
                {
                    Session["MANV"] = obj.MANV.ToString();
                    Session["HOTENNV"] = obj.HOTENNV.ToString();
                    return RedirectToAction("Index", "Lich");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");

                }
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            // Session.Abandon();
            Session.Contents.Remove("MANV");
            Session.Contents.Remove("HOTENNV");
            return RedirectToAction("Login", "Account");
        }
        void connectionString()
        {
            conn.ConnectionString = "data source=TRUNGPC; database=quanlynhaxe;integrated security = SSPI;";
        }
    }
}
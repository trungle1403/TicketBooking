using QLNX.DB;
using QLNX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNX.Controllers
{
    public class LoginController : Controller
    {
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var user = db.KHACHHANG.Where(x => x.SDTKH == model.SDT && x.MATKHAUKH == model.MATKHAU).FirstOrDefault();
                if(user!=null)
                {
                    //lưu session 
                    Session["userid"] = user.MAKH;
                    Session["userten"] = user.HOTENKH;
                    Session["usersdt"] = user.SDTKH;
                    Session["useremail"] = user.EMAIL;
                    Session["usermatkhau"] = user.MATKHAUKH;
                    return RedirectToAction("Index", "MuaVe");
                }else
                {
                    // ViewBag.Alert = "$(document).ready(function () { Swal.fire({ icon: 'warning', title: 'Thông báo', text: 'Đăng nhập không thành công!',confirmButtonText: 'OK',timer: 2500 }) })";
                    ViewBag.Alert = "<h3 style='color:red;text-align:centerl'><b>Đăng nhập không thành công</b></h3>";
                    return View();
                }
               

            }
            return RedirectToAction("Index", "MuaVe");
        }
        public ActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signin(SigninModel model)
        {
            if (ModelState.IsValid)
            {
                KHACHHANG objKh = new KHACHHANG();
                objKh.HOTENKH = model.HOTEN;
                objKh.SDTKH = model.SDT;
                objKh.EMAIL = model.EMAIL;
                objKh.MATKHAUKH = model.MATKHAU;
                objKh.TRANGTHAIKH = "Hoạt động";

                db.KHACHHANG.Add(objKh);
                db.SaveChanges();

                //lưu session 
                Session["userid"] = objKh.MAKH;
                Session["userten"] = objKh.HOTENKH;
                Session["usersdt"] = objKh.SDTKH;
                Session["useremail"] = objKh.EMAIL;
                Session["usermatkhau"] = objKh.MATKHAUKH;

                return RedirectToAction("Index", "MuaVe");
            }
            return View();
        }

        public ActionResult Logout()
        {
           // Session.Abandon();
            Session.Contents.Remove("userid");
            Session.Contents.Remove("userten");
            Session.Contents.Remove("usersdt");
            Session.Contents.Remove("useremail");
            Session.Contents.Remove("usermatkhau");
            return RedirectToAction("Index", "MuaVe");
        }
    }
}
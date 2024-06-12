using QLNX.Areas.Admin.Models;
using QLNX.DB;
using QLNX.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNX.Controllers
{
    public class MyBookingController : Controller
    {
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        // GET: MyBooking
        public ActionResult Index()
        {
            if(Session["userid"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            string makh = Session["userid"].ToString();
            var list = db.Database.SqlQuery<MyBookingModel>(
               "SELECT * FROM PHOIXE, TUYENDUONG, LICHCHAY, XE, CHITIETGHE, GHE, KHACHHANG  WHERE  PHOIXE.MAKH = @makh AND PHOIXE.MALICH = LICHCHAY.MALICH AND  PHOIXE.MATUYEN = TUYENDUONG.MATUYEN AND PHOIXE.MA_XE = XE.MAXE AND XE.MAXE = GHE.MAXE AND PHOIXE.MAPHOI = CHITIETGHE.MAPHOI AND GHE.MAGHE = CHITIETGHE.MAGHE AND PHOIXE.MAKH = KHACHHANG.MAKH order by NGAYDATVE desc",
               new SqlParameter("@makh", makh)
           ).ToList();
            return View(list);
        }
    }
}
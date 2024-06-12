using QLNX.Areas.Admin.Models;
using QLNX.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNX.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            if(Session["MANV"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var list = db.Database.SqlQuery<DonHangModel>(
               "Select HOTENKH, SDTKH, NGAYDATVE, NGAYKHOIHANH, GIOCHAY, DIADIEMDI, DIADIEMDEN, TENGHE, THANHTIEN,TRANGTHAIPHOI, PTTHANHTOAN from PHOIXE, XE, LICHCHAY, TUYENDUONG, KHACHHANG, GHE, CHITIETGHE where KHACHHANG.MAKH = PHOIXE.MAKH and PHOIXE.MA_XE = XE.MAXE and PHOIXE.MALICH = LICHCHAY.MALICH and PHOIXE.MATUYEN = TUYENDUONG.MATUYEN and GHE.MAXE = XE.MAXE and PHOIXE.MAPHOI = CHITIETGHE.MAPHOI and CHITIETGHE.MAGHE = GHE.MAGHE order by NGAYDATVE desc").ToList();
            return View(list);
        }
    }
}
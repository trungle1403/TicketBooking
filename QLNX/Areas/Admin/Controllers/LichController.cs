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
    public class LichController : Controller
    {
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        // GET: Admin/Lich
        public ActionResult Index()
        {
            if (Session["MANV"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBagXe();
            ViewBagTuyen();
            return View();
        }

        public void ViewBagXe(int? selectedID = null)
        {
            ViewBag.listXe = new SelectList(db.XE, "MAXE", "TENXE", selectedID);
        }
        public void ViewBagTuyen(int? selectedID = null)
        {
            var objList = db.TUYENDUONG.ToList();
            IEnumerable<SelectListItem> selectList = from s in objList
                                                     select new SelectListItem
                                                     {
                                                         Value = s.MATUYEN.ToString(),
                                                         Text = s.DIADIEMDI + " - " + s.DIADIEMDEN
                                                     };
            ViewBag.listTuyen = new SelectList(selectList, "Value", "Text");
        }

        public JsonResult GetLichList()
        {
            List<TaoLichModel> list = db.LICHCHAY.Select(x => new TaoLichModel
            {
                MALICH = x.MALICH,

                NGAYKHOIHANH = x.NGAYKHOIHANH,
               
                GIOCHAY = x.GIOCHAY

            }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLichById(string id)
        {
            var list = db.Database.SqlQuery<TaoLichModel>(
               "SELECT * FROM LICH WHERE  MALICH = @malich",
               new SqlParameter("@maich", id)
           ).FirstOrDefault();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveDataInDatabase(TaoLichModel model)
        {
            var s = "";
            try
            {
                //if (model.MALICH != "")
                //{
                //    NHANVIEN nv = db.NHANVIEN.SingleOrDefault(x => x.MANV == model.MANV);
                //    nv.HOTENNV = model.HOTENNV;
                //    nv.SDTNV = model.SDTNV;
                //    nv.CHUCVU = model.CHUCVU;
                //    nv.TRANGTHAINV = model.TRANGTHAINV;
                //    nv.CMND = model.CMND;
                //    db.SaveChanges();
                //    s = "Cập nhật thành công";
                //}
                //else
                {
                    LICHCHAY objLich = new LICHCHAY();
                    objLich.MALICH = Guid.NewGuid().ToString();

                    objLich.NGAYKHOIHANH = model.NGAYKHOIHANH;
                    objLich.GIOCHAY = model.GIOCHAY;
                    objLich.TRANGTHAILICH = "Hoạt động";

                    db.LICHCHAY.Add(objLich);

                    //Tạo phôi xe với lịch trên
                    //lấy giá vé
                    var giaVe = db.XE.Where(x => x.MAXE == model.MAXE).Select(x => x.GIAVE).First();

                    //lấy số ghế để tạo vòng lặp
                    var soGhe = db.XE.Where(x => x.MAXE == model.MAXE).Select(x => x.SOGHE).First();

                    //đếm số ghế 
                    var countSoGhe = db.GHE.Where(x => x.MAXE == model.MAXE).Select(x => x.MAGHE).Count();

                    for (int i = 0; i < countSoGhe; i++)
                    {
                        //khởi tạo mỗi vòng lặp
                        PHOIXE objPhoi = new PHOIXE();
                        objPhoi.MAPHOI = Guid.NewGuid().ToString();
                        objPhoi.MALICH = objLich.MALICH;
                        objPhoi.MATUYEN = model.MATUYEN;
                        objPhoi.NGAYTAOVE = DateTime.Now;
                        objPhoi.TRANGTHAIPHOI = "Ghế trống";
                        objPhoi.MA_XE = model.MAXE;
                        objPhoi.THANHTIEN = giaVe;

                        db.PHOIXE.Add(objPhoi);
                    }
                    db.SaveChanges();
                    taoChiTietGhe(objLich.MALICH);
                    s = "Thêm thành công";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(new { result = true, alert = s }, JsonRequestBehavior.AllowGet);
        }
        public void taoChiTietGhe(string maLich)
        {
            LICHCHAY objLich = new LICHCHAY();
            ChiTietGheModel objChiTiet = new ChiTietGheModel();
            //lấy mã xe từ mã lịch trong Phôi xe
            var maXe = db.PHOIXE.Where(x => x.MALICH == maLich).Select(x => x.MA_XE).First();
            //lấy danh sách mã ghế từ mã xe trên
            var dsGhe = db.GHE.Where(x => x.MAXE == maXe).Select(x => x.MAGHE).ToList();

            //lấy danh sách mã phôi từ mã lịch trong Phôi xe
            var dsMaPhoi = db.PHOIXE.Where(x => x.MALICH == maLich).Select(x => x.MAPHOI).ToList();

            //đếm số ghế 
            var countSoGhe = db.GHE.Where(x => x.MAXE == maXe).Select(x => x.MAGHE).Count();

            for (int i = 0; i < countSoGhe; i++)
            {
                objChiTiet.CreateChiTietGhe(dsMaPhoi[i], dsGhe[i]);
            }

        }

        public JsonResult DeleteRecord(string id)
        {
            bool result = false;
            LICHCHAY nv = db.LICHCHAY.Find(id);
            if (nv != null)
            {
                db.LICHCHAY.Remove(nv);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
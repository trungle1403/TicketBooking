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
    public class XeController : Controller
    {
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        // GET: Admin/Xe
        public ActionResult Index()
        {
            if (Session["MANV"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBagTT();
            ViewBagNhanVien();
            ViewBagSoghe();
            return View();
        }

        public void ViewBagNhanVien(int? selectedID = null)
        {
            var objList = db.NHANVIEN.Where(x=>x.CHUCVU == "Tài xế").ToList();
            IEnumerable<SelectListItem> selectList = from s in objList
                                                     select new SelectListItem
                                                     {
                                                         Value = s.MANV.ToString(),
                                                         Text = s.HOTENNV 
                                                     };
            ViewBag.listNhanvien = new SelectList(selectList, "Value", "Text");
        }
        public void ViewBagTT()
        {
            List<SelectModel> ListTT = new List<SelectModel>()
            {
                new SelectModel() {values = "Hoạt động", text="--Chọn trạng thái xe--" },
                new SelectModel() {values = "Hoạt động", text="Hoạt động" },
                new SelectModel() {values = "Đang sửa chữa", text="Đang sửa chữa" },
            };
            ViewBag.listTrangThai = new SelectList(ListTT, "values", "text");
        }
        public void ViewBagSoghe()
        {
            List<SelectModel> ListSoGhe = new List<SelectModel>()
            {
                new SelectModel() {values = "", text="--Chọn số ghế--" },
                new SelectModel() {values = "16", text="16 ghế" },
                new SelectModel() {values = "30", text="30 ghế" },
                new SelectModel() {values = "47", text="47 ghế"},
            };
            ViewBag.listSoghe = new SelectList(ListSoGhe, "values", "text");
        }
        public JsonResult GetXeList()
        {
            List<XeModel> list = db.XE.Select(x => new XeModel
            {
                MAXE = x.MAXE,
                TENXE = x.TENXE,
                SOGHE = x.SOGHE,
                GIAVE = x.GIAVE,
                HANGXE = x.HANGXE,
                BIENXE = x.BIENXE,
                HINHANH = x.HINHANH,
                TRANGTHAIXE = x.TRANGTHAIXE,
                HOTENNV = x.NHANVIEN.HOTENNV
            }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetXeById(int? id)
        {
            var list = db.Database.SqlQuery<XeModel>(
               "SELECT * FROM XE WHERE   MAXE = @maxe",
               new SqlParameter("@maxe", id.ToString())
           ).FirstOrDefault();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(XeModel model)
        {
            var s = "";
            try
            {
                if (model.MAXE > 0)
                {
                    XE x = db.XE.SingleOrDefault(a => a.MAXE == model.MAXE);
                    x.TENXE = model.TENXE;
                    x.SOGHE = model.SOGHE;
                    x.GIAVE = model.GIAVE;
                    x.HANGXE = model.HANGXE;
                    x.BIENXE = model.BIENXE;
                    x.TRANGTHAIXE = model.TRANGTHAIXE;
                    x.MANV = model.MANV;
                    db.SaveChanges();
                    s = "Cập nhật thành công";
                }
                else
                {
                    XE x = new XE();
                    x.TENXE = model.TENXE;
                    x.SOGHE = model.SOGHE;
                    x.GIAVE = model.GIAVE;
                    x.HANGXE = model.HANGXE;
                    x.HINHANH = "Upload/phuvl.jpg";
                    x.BIENXE = model.BIENXE;
                    x.TRANGTHAIXE = model.TRANGTHAIXE;
                    x.MANV = model.MANV;
                    db.XE.Add(x);
                    db.SaveChanges();
                    s = "Thêm thành công";


                    //sau khi đã tạo xong xe mới thì lấy mã xe mới tạo số ghế

                    GHE objGhe = new GHE();
                    if (x.SOGHE == 16) //16 ghế
                    {
                        for (int i = 2; i <= 16; i++)
                        {
                            objGhe.MAXE = x.MAXE;
                            objGhe.TRANGTHAIGHE = "Hoạt động";
                            objGhe.TENGHE = "Ghế số " + i;
                            db.GHE.Add(objGhe);
                            db.SaveChanges();
                        }
                    }
                    else if (x.SOGHE == 30) //30 ghế
                    {
                        for (int i = 1; i <= 15; i++)
                        {
                            objGhe.MAXE = x.MAXE;
                            objGhe.TRANGTHAIGHE = "Hoạt động";
                            objGhe.TENGHE = "Ghế số " + i + "A";
                            db.GHE.Add(objGhe);
                            db.SaveChanges();
                        }
                        for (int i = 1; i <= 15; i++)
                        {
                            objGhe.MAXE = x.MAXE;
                            objGhe.TRANGTHAIGHE = "Hoạt động";
                            objGhe.TENGHE = "Ghế số " + i + "B";
                            db.GHE.Add(objGhe);
                            db.SaveChanges();
                        }
                    }
                    else //47 ghế
                    {
                        for (int i = 1; i <= 20; i++)
                        {
                            objGhe.MAXE = x.MAXE;
                            objGhe.TRANGTHAIGHE = "Hoạt động";
                            objGhe.TENGHE = "Ghế số " + i + "-A";
                            db.GHE.Add(objGhe);
                            db.SaveChanges();
                        }
                        for (int i = 1; i <= 20; i++)
                        {
                            objGhe.MAXE = x.MAXE;
                            objGhe.TRANGTHAIGHE = "Hoạt động";
                            objGhe.TENGHE = "Ghế số " + i + "-B";
                            db.GHE.Add(objGhe);
                            db.SaveChanges();
                        }
                        for (int i = 21; i <= 26; i++)
                        {
                            objGhe.MAXE = x.MAXE;
                            objGhe.TRANGTHAIGHE = "Hoạt động";
                            objGhe.TENGHE = "Ghế số " + i;
                            db.GHE.Add(objGhe);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(new { result = true, alert = s } , JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRecord(int id)
        {
            bool result = false;
            XE xe = db.XE.SingleOrDefault(x => x.MAXE == id);
            if (xe != null)
            {
                db.XE.Remove(xe);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}
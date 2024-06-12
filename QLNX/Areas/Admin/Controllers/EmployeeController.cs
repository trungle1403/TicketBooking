using Newtonsoft.Json;
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
    public class EmployeeController : Controller
    {
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        // GET: Admin/Employee
        public ActionResult Index()
        {
            if (Session["MANV"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<SelectModel> ListTT = new List<SelectModel>()
            {
                new SelectModel() {values = "Hoạt động", text="--Chọn trạng thái--" },
                new SelectModel() {values = "Hoạt động", text="Hoạt động" },
                new SelectModel() {values = "Đã nghỉ", text="Đã nghỉ" },
            };
            // Retrieve departments and build SelectList
            ViewBag.listTrangThai = new SelectList(ListTT, "values", "text");

            List<SelectModel> ListCV = new List<SelectModel>()
            {
                new SelectModel() {values = "Tài xế", text="--Chọn chức vụ--" },
                new SelectModel() {values = "Tài xế", text="Tài xế" },
                new SelectModel() {values = "Nhân viên", text="Nhân viên" },
            };
            // Retrieve departments and build SelectList
            ViewBag.listChucVu = new SelectList(ListCV, "values", "text");
            return View();
        }
        public JsonResult GetEmployeeList()
        {
            List<EmployeeModel> list = db.NHANVIEN.Select(x => new EmployeeModel
            {
                MANV = x.MANV,
                HOTENNV = x.HOTENNV,
                SDTNV = x.SDTNV,
                CHUCVU = x.CHUCVU,
                CMND = x.CMND,
                MATKHAUNV = x.MATKHAUNV,
                TRANGTHAINV = x.TRANGTHAINV
            }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployeeById(int? id)
        {
            var list = db.Database.SqlQuery<EmployeeModel>(
               "SELECT * FROM NHANVIEN WHERE   MANV = @manv",
               new SqlParameter("@manv", id.ToString())
           ).FirstOrDefault();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(EmployeeModel model)
        {
            var s = "";
            try
            {
                if (model.MANV > 0)
                {
                    NHANVIEN nv = db.NHANVIEN.SingleOrDefault(x=>x.MANV == model.MANV);
                    nv.HOTENNV = model.HOTENNV;
                    nv.SDTNV = model.SDTNV;
                    nv.CHUCVU = model.CHUCVU;
                    nv.TRANGTHAINV = model.TRANGTHAINV;
                    nv.CMND = model.CMND;
                    db.SaveChanges();
                    s = "Cập nhật thành công";
                }
                else
                {
                    NHANVIEN nv = new NHANVIEN();
                    nv.HOTENNV = model.HOTENNV;
                    nv.SDTNV = model.SDTNV;
                    nv.CHUCVU = model.CHUCVU;
                    nv.TRANGTHAINV = model.TRANGTHAINV;
                    nv.CMND = model.CMND;
                    nv.MATKHAUNV = model.CMND;
                    db.NHANVIEN.Add(nv);
                    db.SaveChanges();
                    s = "Thêm thành công";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(new { result = true, alert = s }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRecord(int id)
        {
            bool result = false;
            NHANVIEN nv = db.NHANVIEN.SingleOrDefault( x=>x.MANV == id);
            if (nv != null)
            {
                db.NHANVIEN.Remove(nv);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
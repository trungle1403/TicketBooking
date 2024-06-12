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
    public class GheController : Controller
    {
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        // GET: Admin/Ghe
        public ActionResult Index()
        {
            if (Session["MANV"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public JsonResult GetGheList() // id xe => list ghế của xe đó
        {
            List<GheModel> list = db.GHE.Select(x => new GheModel
            {
                MAGHE =x.MAGHE,
                TENXE =x.XE.TENXE,
                TENGHE = x.TENGHE,
                HANG = x.HANG,
                COT = x.COT
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGheById(int? id)
        {
            var list = db.Database.SqlQuery<GheModel>(
               "SELECT * FROM GHE WHERE   MAGHE = @maghe",
               new SqlParameter("@maghe", id.ToString())
           ).FirstOrDefault();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveDataInDatabase(GheModel model)
        {
            var s = "";
            try
            {
                if (model.MAGHE > 0)
                {
                    GHE g = db.GHE.SingleOrDefault(x => x.MAGHE == model.MAGHE);
                    g.TENGHE = model.TENGHE;
                    g.HANG = model.HANG;
                    g.COT = model.COT;
                    db.SaveChanges();
                    s = "Cập nhật thành công";
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(new { result = true, alert = s }, JsonRequestBehavior.AllowGet);
        }
    }
}
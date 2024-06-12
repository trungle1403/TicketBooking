using QLNX.Areas.Admin.Models;
using QLNX.Concrete;
using QLNX.DB;
using QLNX.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QLNX.Controllers
{
    public class MuaVeController : Controller
    {
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        // GET: MuaVe
        public ActionResult Index()
        {
            ViewBagDiaDiem();
            return View();
        }

        [HttpPost]
        public ActionResult Index(LichModel model)
        {
            ViewBagDiaDiem();
            if (ModelState.IsValid)
            {
                Session["diemdi"] = model.DIADIEMDI;
                Session["diemden"] = model.DIADIEMDEN;
                Session["ngay"] = model.NGAYKHOIHANH;
                return RedirectToAction("Lich");
            }
            return View();

        }
        public void ViewBagDiaDiem(int? selectedID = null)
        {
            ViewBag.listDiaDiem = new SelectList(db.TUYENDUONG, "DIADIEMDI", "DIADIEMDI", selectedID);
        }
        public ActionResult Lich()
        {
            if (Session["diemdi"] == null || Session["diemden"] == null || Session["ngay"] == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ngay = string.Format("{0:dd/MM/yyyy}", Session["ngay"]);
            //var objList = db.LICHCHAY.ToList();
            //IEnumerable<SelectListItem> selectList = from s in objList where model.NGAYKHOIHANH == s.NGAYKHOIHANH
            //                                         select new SelectListItem
            //                                         {
            //                                             Value = s.MALICH.ToString(),
            //                                             Text = s.GIOCHAY
            //                                         };
            //ViewBag.listGio = new SelectList(selectList, "Value", "Text");

            var list = db.Database.SqlQuery<ChonXeModel>(
               "Select DISTINCT XE.MAXE, TENXE, HINHANH,  XE.GIAVE,LICHCHAY.MALICH, LICHCHAY.GIOCHAY, DIADIEMDI,DIADIEMDEN, SOGHE,THOIGIANCHAY,DODAI " +
               "from TUYENDUONG,LICHCHAY ,XE ,PHOIXE " +
               "WHERE TUYENDUONG.MATUYEN = PHOIXE.MATUYEN and LICHCHAY.MALICH = PHOIXE.MALICH and XE.MAXE = PHOIXE.MA_XE and DIADIEMDI = @diemdi and DIADIEMDEN =@diemden " +
               "and NGAYKHOIHANH = @ngay order by GIOCHAY asc",
               new SqlParameter("@diemdi", Session["diemdi"]),
               new SqlParameter("@diemden", Session["diemden"]),
               new SqlParameter("@ngay", Session["ngay"])
           ).ToList();

            Session["solich"] = list.Count();

            return View("Lich", list);

        }
        

        public ActionResult DatVe(string id) // mã lịch
        {

            if (id == null)
            {
                return RedirectToAction("Lich");
            }

            //select phôi từ id trên để kiểm tra
            var phoi = db.PHOIXE.Where(x => x.MALICH == id).ToList();
            if(phoi == null)
            {
                return RedirectToAction("Lich");
            }

            //lấy giờ gán vào session sử dụng
            var gio = db.LICHCHAY.Where(x => x.MALICH == id).Select(x => x.GIOCHAY).First();
            Session["giochay"] = gio;

            // ngày khởi hành
            if (Session["ngay"] != null)
            {
                Session["ngay"] = string.Format("{0:dd-MM-yyyy}", Session["ngay"]);
            }

            //lấy mã tuyến gán vào session
            var matuyen = db.PHOIXE.Where(x => x.MALICH == id).Select(x => x.MATUYEN).FirstOrDefault();
            Session["matuyen"] = matuyen;

            //lấy giá vé gán vào session
            var maxe = db.PHOIXE.Where(x => x.MALICH == id).Select(x => x.MA_XE).FirstOrDefault();

            var giave = db.XE.Where(x => x.MAXE == maxe).Select(x => x.GIAVE).FirstOrDefault();
            Session["giave"] = giave;

            //var list = db.PHOIXE.Where(x => x.MALICH == id).ToList();
            var list = db.Database.SqlQuery<DatVeModel>(
               "SELECT PHOIXE.MAPHOI, TRANGTHAIPHOI, TENGHE,HANG,COT,GIAVE FROM PHOIXE, XE, GHE, CHITIETGHE WHERE MA_XE = XE.MAXE and PHOIXE.MAPHOI = CHITIETGHE.MAPHOI and GHE.MAXE = XE.MAXE and GHE.MAGHE = CHITIETGHE.MAGHE and MALICH = @malich",
               new SqlParameter("@malich", id.ToString())
           ).ToList();
            // đếm số phôi xe tương đương số ghế
            Session["soghe"] = list.Count();
            Session["idphoi"] = id;
            if (list.Count() == 0)
            {
                return RedirectToAction("Lich");
            }
            return View(list);
        }

        // khi user click đặt
        [HttpPost]
        public ActionResult DatVe(DatVeModel model)
        {
            //lấy mã phôi
            Session["cart"] = model.chuoiId;

            //tổng tiền
            Session["tongtien"] = model.tongtien;

           

            //lấy ghế đã chọn gửi qua chi tiết vé
            Session["ghedachon"] = model.ghedachon;
            return RedirectToAction("ChiTietVe");
        }
        public ActionResult ChiTietVe()
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("DatVe", Session["idphoi"]);
            }
            if (Session["diemdi"] == null || Session["diemdi"] == null)
            {
                return RedirectToAction("Index");
            }

            if (Session["matuyen"] != null)
            {
                var objTram = db.TRAM.ToList();
                IEnumerable<SelectListItem> selectList = from s in objTram
                                                         where s.MATUYEN == Convert.ToInt32(Session["matuyen"])
                                                         select new SelectListItem
                                                         {
                                                             Value = s.MATRAM.ToString(),
                                                             Text = s.TENTRAM + " - " + s.DIACHI
                                                         };
                ViewBag.listTram = new SelectList(selectList, "Value", "Text");
            }

            List<SelectModel> ListPTTT = new List<SelectModel>()
            {
                new SelectModel() {values = "", text="--Chọn phương thức thanh toán--" },
                new SelectModel() {values = "Chuyển khoản ngân hàng", text="Chuyển khoản ngân hàng" },
                new SelectModel() {values = "Ví MoMo", text="Ví MoMo" },
                new SelectModel() {values = "Zalo Pay", text="Zalo Pay" },
                new SelectModel() {values = "Thẻ Visa - MasterCard", text="Thẻ Visa - MasterCard" },
            };
            // Retrieve departments and build SelectList
            ViewBag.listPTTT = new SelectList(ListPTTT, "values", "text");
            return View();
        }

        //Khi user click thanh toán
        [HttpPost]
        public ActionResult ChiTietVe(CheckoutModel model)
        {
            if (Session["matuyen"] != null)
            {
                var objTram = db.TRAM.ToList();
                IEnumerable<SelectListItem> selectList = from s in objTram
                                                         where s.MATUYEN == Convert.ToInt32(Session["matuyen"])
                                                         select new SelectListItem
                                                         {
                                                             Value = s.MATRAM.ToString(),
                                                             Text = s.TENTRAM + " - " + s.DIACHI
                                                         };
                ViewBag.listTram = new SelectList(selectList, "Value", "Text");
            }else
            {
                return RedirectToAction("DatVe");
            }
            if (ModelState.IsValid)
            {
                int maKH;
                KHACHHANG objKhachhang = new KHACHHANG();
                if (Session["userid"] != null)
                {
                    maKH = Convert.ToInt32(Session["userid"]);
                }else
                {
                    //tạo khách hàng
                   
                    objKhachhang.HOTENKH = model.HOTEN;
                    objKhachhang.EMAIL = model.EMAIL;
                    objKhachhang.SDTKH = model.SDT;
                    objKhachhang.TRANGTHAIKH = "Hoạt động";
                    // điểm đón là mã trạm
                    objKhachhang.DIEMDON = model.MATRAM;
                    //tạo mật khẩu để gửi qua email khách hàng
                    objKhachhang.MATKHAUKH = Guid.NewGuid().ToString();
                    Session["matkhaugui"] = objKhachhang.MATKHAUKH;


                    //thêm
                    db.KHACHHANG.Add(objKhachhang);
                    //save
                    db.SaveChanges();

                    maKH = Convert.ToInt32(objKhachhang.MAKH);
                }

                

                //sau khi thêm thông tin khách hàng, tiến hành thêm mã khách hàng vào phôi và cập nhật trạng thái phôi
                //lấy ghế được chọn gán vào list
                string cart = Session["cart"].ToString();
                string[] list = cart.Split(',');

                //update tất cả phôi được chọn
                //for (int i =0; i < list.Length -1;i++)
                //{
                //    //update phôi xe
                //    var update = db.Database.SqlQuery<PHOIXE>(
                //       "Update PHOIXE set MAKH = @makh, NGAYDATVE = @ngaydatve, THANHTIEN = @thanhtien, TRANGTHAIPHOI = @trangthai,"+
                //        "PTTHANHTOAN = @ptthanhtoan where MAPHOI = @maphoi",
                //       new SqlParameter("@makh", objKhachhang.MAKH),
                //       new SqlParameter("@ngaydatve", DateTime.Now),
                //       new SqlParameter("@thanhtien", Convert.ToDecimal(Session["giave"])),
                //       new SqlParameter("@trangthai", "Ghế đã đặt"),
                //       new SqlParameter("@ptthanhtoan", model.PTTHANHTOAN),
                //       new SqlParameter("@maphoi", list[i])).First();
                //}


                //foreach (var item in list)
                //{
                //    //update phôi xe
                //    var update = db.Database.SqlQuery<PHOIXE>(
                //       "Update PHOIXE set MAKH = @makh, NGAYDATVE = @ngaydatve, TRANGTHAIPHOI = @trangthai," +
                //        "PTTHANHTOAN = @ptthanhtoan where MAPHOI = @maphoi",
                //       new SqlParameter("@makh", objKhachhang.MAKH),
                //       new SqlParameter("@ngaydatve", DateTime.Now),
                //       new SqlParameter("@trangthai", "Ghế đã đặt"),
                //       new SqlParameter("@ptthanhtoan", model.PTTHANHTOAN),
                //       new SqlParameter("@maphoi", item)
                //       ).First();
                //}

               

                foreach (var item in list)
                {
                    //lấy phôi xe có mã phôi là item
                    var listUpdate = db.PHOIXE.Where(x => x.MAPHOI == item).FirstOrDefault();
                    //update phôi xe đã lấy ở trên
                    listUpdate.MAKH = maKH;
                    listUpdate.NGAYDATVE = DateTime.Now;
                    listUpdate.TRANGTHAIPHOI = "Ghế đã đặt";
                    listUpdate.PTTHANHTOAN = model.PTTHANHTOAN.ToString();

                    db.Entry(listUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                }


                // gửi email
                string subject = "Đơn hàng mới - Vé đi " + Session["diemdi"] + " - " + Session["diemden"];
                List<string> cc = new List<string>() { "trungleit99@gmail.com" };

                StringBuilder sb = new StringBuilder();
                sb.Append($"<h3 style='font-weight:bold;'>Xin chào anh, chị <span style='color:#423caa;'>{ model.HOTEN } </span> </h3>");
                sb.Append("<p>Cám ơn bạn đã quan tâm dịch vụ của chúng tôi. Đơn hàng của bạn đã được xác nhận và thanh toán.</p>");

                sb.Append("<table style='border-collapse:collapse;width:100%;border-top:1px solid #dddddd;border-left:1px solid #dddddd;margin-bottom:20px'>");
                sb.Append(" <thead> <tr>");
                sb.Append("<th style='font-size:12px;border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;background-color:#efefef;font-weight:bold;text-align:left;padding:7px;color:#222222' colspan='2'>Chi tiết đơn hàng</th>");

                sb.Append("</tr> </thead>  <tbody> ");
                //bắt đầu tr 
                sb.Append("<tr>");
                sb.Append($"<td style='font-size:12px;border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;text-align:left;padding:7px'> <b>Ghế đã đặt: </b> {@Session["ghedachon"]} <br>  <b>Thời gian đặt vé: </b>  { DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") } <br> <b>Tuyến đường: </b> { Session["diemdi"] + " - " + Session["diemden"] } <br> <b>Phương thức thanh toán: </b> {model.PTTHANHTOAN} </td>");
                sb.Append($"<td style='font-size:12px;border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;text-align:left;padding:7px'> <b>Giá mỗi vé: </b> {String.Format("{0:n0}", @Session["giave"])} VND <br>      <b>Số lượng vé: </b> {list.Length}             <br> <b>Tổng cộng: </b> {String.Format("{0:n0}",  @Session["tongtien"]) } VND    <br> <b> Tình trạng:  </b> <span style='color:#4f9fcf;font-weight:bold;'>Đã thanh toán</span>  </td>");
                sb.Append("</tr>");
                //end tr

                sb.Append("</tbody> </table> ");
                //mật khẩu
                if (Session["usermatkhau"] == null)
                {
                    sb.Append($"<b>Mật khẩu của quý khách:</b>   <span style='color:#423caa;'>{ objKhachhang.MATKHAUKH}</span>");
                    sb.Append("<h4 style='font-weight:bold'>Lưu ý: </h4> <label>Quý khách hãy đổi mật khẩu mới sau khi đăng nhập!</label>");
                }
               
                sb.Append("<h4 style='font-weight:bold'> Trân trọng cảm ơn!!! </h4>");

                sb.Append("------------------------------------------------------- <br>");
                sb.Append("Lê Nguyễn Chí Trung <br>");
                sb.Append("Email: <a href='mailto:trungleit99@gmail.com' target='blank'>trungleit99@gmail.com</a>");

                //gửi email
                var mailSender = new EmailHelper();
                //email người dùng, tiêu đề email, nội dung, người gửi
                mailSender.Send(model.EMAIL, subject, sb.ToString(), cc);

                //xóa session
                // Session.Abandon();

                Session.Contents.Remove("cart");
                Session.Contents.Remove("matuyen");
                Session.Contents.Remove("ghedachon");
                Session.Contents.Remove("giave");
                Session.Contents.Remove("tongtien");

                return RedirectToAction("Successful");
            }
            return View();
        }

        public ViewResult Successful()
        {
            return View();
        }

    }
}

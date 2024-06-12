using QLNX.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLNX.Areas.Admin.Models
{
    public class TaoLichModel
    {
        //lịch
        public string MALICH { get; set; }

        //[Required(ErrorMessage = "Chưa chọn ngày")]
        //[DataType(DataType.Date)]
        //[Display(Name = "Ngày khởi hành")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NGAYKHOIHANH { get; set; }

        [Required(ErrorMessage = "Chưa chọn giờ")]
        [Display(Name = "Giờ")]
        public string GIOCHAY { get; set; }

        [Display(Name = "Trạng thái")]
        public string TRANGTHAILICH { get; set; }

        //xe

        [Required(ErrorMessage ="Chưa chọn xe")]
        public int? MAXE { get; set; }
        public string TENXE { get; set; }




        //tuyến
        [Required(ErrorMessage = "Chưa chọn tuyến")]
        public int? MATUYEN { get; set; }
        public string DIADIEMDI { get; set; }
        public string DIADIEMDEN { get; set; }

       
       

    }
}
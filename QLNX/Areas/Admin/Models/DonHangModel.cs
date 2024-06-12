using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNX.Areas.Admin.Models
{
    public class DonHangModel
    {
        //Phôi xe
        public string MAPHOI { get; set; }
        public string MALICH { get; set; }
        public int MATUYEN { get; set; }
        public int MAKH { get; set; }
        public int MAXE { get; set; }
        public DateTime NGAYDATVE { get; set; }
        public decimal THANHTIEN { get; set; }
        public string TRANGTHAIPHOI { get; set; }
        public string PTTHANHTOAN { get; set; }


        // ghế
        public string TENGHE { get; set; }


        //tuyến
        public string DIADIEMDI { get; set; }
        public string DIADIEMDEN { get; set; }


        //Lịch
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NGAYKHOIHANH { get; set; }
        public string GIOCHAY { get; set; }

        //khách hàng
        public string HOTENKH { get; set; }
        public string SDTKH { get; set; }



    }
}
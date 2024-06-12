using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLNX.Models
{
    public class MyBookingModel
    {
        public int MAKH { get; set; }
        public DateTime NGAYDATVE { get; set; }
        public DateTime NGAYKHOIHANH { get; set; }
        public string GIOCHAY { get; set; }
        public string DIADIEMDI { get; set; }
        public string DIADIEMDEN { get; set; }
        public string TENGHE { get; set; }
        public string PTTHANHTOAN { get; set; }
        public decimal THANHTIEN { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNX.Models
{
    [Serializable]
    public class ChonXeModel
    {
        [Required(ErrorMessage = "Chưa chọn điểm đi")]
        public string DIADIEMDI { get; set; }

        [Required(ErrorMessage = "Chưa chọn điểm đến")]
        public string DIADIEMDEN { get; set; }


        [Required(ErrorMessage = "Chưa chọn ngày")]
        [Display(Name = "Ngày")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NGAYKHOIHANH { get; set; }

        [Required(ErrorMessage = "Chưa chọn giờ")]
        [Display(Name = "Giờ")]
        public string GIOCHAY { get; set; }


        public int MAXE { get; set; }
        public string TENXE { get; set; }
        public decimal GIAVE { get; set; }
        public int SOGHE { get; set; }
        public string HINHANH { get; set; }



        // table phôi xe
        public string MAPHOI { get; set; }
        public string TRANGTHAIPHOI { get; set; }
        public DateTime NGAYDATVE { get; set; }

        //table ghế
        public int MAGHE { get; set; }
        public string TENGHE { get; set; }

        public string THOIGIANCHAY { get; set; }
        public string DODAI { get; set; }

        public int MATUYEN { get; set; }

        public string MALICH { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLNX.DB;
using System.ComponentModel.DataAnnotations;

namespace QLNX.Models
{
    [Serializable]
    public class LichModel
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

        

    }
}
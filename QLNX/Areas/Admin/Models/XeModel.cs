using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNX.Areas.Admin.Models
{
    public class XeModel
    {
        public int MAXE { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên xe")]
        [Display(Name = "Tên xe")]
        public string TENXE { get; set; }

        [Required(ErrorMessage = "Chưa nhập hãng xe")]
        [Display(Name = "Hãng xe")]
        public string HANGXE { get; set; }

        [Required(ErrorMessage = "Chưa chọn số ghế")]
        [Display(Name = "Số ghế")]
        public Nullable<int> SOGHE { get; set; }
        public string HINHANH { get; set; }

        [Required(ErrorMessage = "Chưa nhập giá vé")]
        [Display(Name = "Giá vé")]
        public Nullable<decimal> GIAVE { get; set; }

        [Required(ErrorMessage = "Chưa nhập biển số xe")]
        [Display(Name = "Biển xe")]
        public string BIENXE { get; set; }

        [Required(ErrorMessage = "Chưa chọn trạng thái")]
        [Display(Name = "Trạng thái")]
        public string TRANGTHAIXE { get; set; }

        [Display(Name = "Tên tài xế")]
        public Nullable<int> MANV { get; set; }

        public string HOTENNV { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace QLNX.Areas.Admin.Models
{
    public partial class LichChayModel
    {

        public string MALICH { get; set; }

        [Required(ErrorMessage = "Chưa chọn ngày")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày khởi hành")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> NGAYKHOIHANH { get; set; }

        [Required(ErrorMessage = "Chưa chọn giờ")]
        [Display(Name = "Giờ")]
        public string GIOCHAY { get; set; }

        [Display(Name = "Trạng thái")]
        public string TRANGTHAILICH { get; set; }


    }
}
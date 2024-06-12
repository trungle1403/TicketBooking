using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNX.Areas.Admin.Models
{
    public class EmployeeModel
    {
        public int MANV { get; set; }

        [Required(ErrorMessage = "Chưa nhập họ tên")]
        [Display(Name = "Họ tên")]
        public string HOTENNV { get; set; }

        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        public string SDTNV { get; set; }
        public string CHUCVU { get; set; }

        [Required(ErrorMessage = "Chưa nhập chứng minh")]
        [Display(Name = "Chứng minh nhân dân")]
        public string CMND { get; set; }

        [MinLength(3)]
        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string MATKHAUNV { get; set; }
        public string TRANGTHAINV { get; set; }
    }
}
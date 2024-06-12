using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNX.Models
{
    public class CheckoutModel
    {
        //checkout
        public int MATRAM { get; set; }

        [Required(ErrorMessage = "Chưa nhập họ tên")]
        public string HOTEN { get; set; }


        [Required(ErrorMessage = "Chưa nhập email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không hợp lệ")]
        public string EMAIL { get; set; }


        [RegularExpression(@"^.{3,}$", ErrorMessage = "Số điện thoại phải đủ 10 số")]
        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Tối đa 10 số")]
        public string SDT { get; set; }

        public string DIEMDON { get; set; }
        public string TRANGTHAI { get; set; }
        public string PTTHANHTOAN { get; set; }
    }
}
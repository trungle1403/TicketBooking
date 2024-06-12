using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNX.Models
{
    public class LoginModel
    {
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Số điện thoại phải đủ 10 số")]
        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Tối đa 10 số")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        public string MATKHAU { get; set; }
    }
}
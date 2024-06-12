using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLNX.Areas.Admin.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Chưa nhập Username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Chưa nhập Password")]
        public string PassWord { set; get; }


    }
}
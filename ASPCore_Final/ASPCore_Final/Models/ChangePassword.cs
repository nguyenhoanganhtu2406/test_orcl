using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore_Final.Models
{
    public class ChangePassword
    {
        [Display(Name = "MK Mới")]
        public string MatKhauMoi { set; get; }
        [Display(Name = "Xác nhận MK")]
        public string XacNhanMatKhauMoi { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }
        [Display(Name = "Mã NCC")]
        public string Mancc { get; set; }
        [Display(Name = "Tên Cty")]
        public string Tencongty { get; set; }
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        public string Dienthoai { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }

        public ICollection<Hanghoa> Hanghoa { get; set; }
    }
}

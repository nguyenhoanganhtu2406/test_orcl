using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class Nhanvien
    {
        [Display(Name = "Mã NV")]
        public int Manv { get; set; }
        [Display(Name = "Họ Tên")]
        public string Hoten { get; set; }

        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Matkhau { get; set; }
        [Display(Name = "Mã PQ")]
        public int Mapq { get; set; }
        [Display(Name = "Trạng thái HĐ")]
        public bool? Trangthaihd { get; set; }
        [Display(Name = "Mã PQ")]
        public Phanquyen MapqNavigation { get; set; }
    }
}

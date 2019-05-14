using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadon = new HashSet<Hoadon>();
        }
        [Display(Name = "Mã KH")]
        public int Makh { get; set; }
        [Display(Name = "Mật Khẩu")]
        public string Matkhau { get; set; }
        [Display(Name = "Họ Tên")]
        public string Hoten { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Display(Name = "SĐT")]
        public string Dienthoai { get; set; }
        public string Email { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Tài khoản")]
        public string Taikhoan { get; set; }
        [Display(Name = "Giới Tính")]
        public string Gioitinh { get; set; }
        [Display(Name = "Ngày Sinh")]
        public DateTime? Ngaysinh { get; set; }
        [Display(Name = "Trạng thái HĐ")]
        public bool? Trangthaihd { get; set; }

        public ICollection<Hoadon> Hoadon { get; set; }
    }
}

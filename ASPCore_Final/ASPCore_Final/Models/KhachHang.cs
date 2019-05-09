using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadon = new HashSet<Hoadon>();
        }

        public int Makh { get; set; }
        public string Matkhau { get; set; }
        public string Hoten { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }
        public string Email { get; set; }
        public string Hinh { get; set; }
        public string Taikhoan { get; set; }
        public string Gioitinh { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public bool? Trangthaihd { get; set; }

        public ICollection<Hoadon> Hoadon { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class PhieuNhapHang
    {
        public PhieuNhapHang()
        {
            ChiTietPhieuNhap = new HashSet<ChiTietPhieuNhap>();
        }
        [Display(Name = "Mã PN")]
        public int MaPn { get; set; }
        [Display(Name = "Ngày nhập")]
        public DateTime NgayNhap { get; set; }
        [Display(Name = "Tổng tiền")]
        public double? TongTien { get; set; }

        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
    }
}

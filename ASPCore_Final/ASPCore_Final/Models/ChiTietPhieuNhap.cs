using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class ChiTietPhieuNhap
    {
        [Display(Name = "Mã PN")]
        public int MaPn { get; set; }
        [Display(Name = "Mã HH")]
        public int MaHh { get; set; }
        [Display(Name = "Kích Cỡ")]
        public string KichCo { get; set; }
        [Display(Name = "Số Lượng")]
        public int? SoLuongNhap { get; set; }
        [Display(Name = "Đơn Giá")]
        public double? DonGiaNhap { get; set; }
        [Display(Name = "Mã HH")]
        public HangHoa MaHhNavigation { get; set; }
        [Display(Name = "Mã PN")]
        public PhieuNhapHang MaPnNavigation { get; set; }
    }
}

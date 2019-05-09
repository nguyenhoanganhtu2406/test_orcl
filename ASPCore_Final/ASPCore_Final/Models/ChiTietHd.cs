using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class ChiTietHd
    {
        [Display(Name = "Mã CT")]
        public int MaCt { get; set; }
        [Display(Name = "Mã HĐ")]
        public int MaHd { get; set; }
        [Display(Name = "Mã HH")]
        public int MaHh { get; set; }
        [Display(Name = "Đơn Giá")]
        public double DonGia { get; set; }
        [Display(Name = "Giảm Giá")]
        public double? GiamGia { get; set; }
        [Display(Name = "Số Lượng")]
        public int SoLuong { get; set; }
        [Display(Name = "Kích Cỡ")]
        public string KichCo { get; set; }
        [Display(Name = "Mã HĐ")]
        public HoaDon MaHdNavigation { get; set; }
        [Display(Name = "Mã HH")]
        public HangHoa MaHhNavigation { get; set; }
    }
}

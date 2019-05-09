using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class YeuThich
    {
        [Display(Name = "Mã YT")]
        public int MaYt { get; set; }
        [Display(Name = "Mã HH")]
        public int? MaHh { get; set; }
        [Display(Name = "Mã KH")]
        public int? MaKh { get; set; }
        [Display(Name = "Ngày chọn")]
        public DateTime? NgayChon { get; set; }
        [Display(Name = "Điểm đánh giá")]
        public double DiemDanhGia { get; set; }
        [Display(Name = "Mã BL")]
        public int? MaBl { get; set; }
        [Display(Name = "Mã HH")]
        public HangHoa MaHhNavigation { get; set; }
        [Display(Name = "Mã KH")]
        public KhachHang MaKhNavigation { get; set; }
    }
}

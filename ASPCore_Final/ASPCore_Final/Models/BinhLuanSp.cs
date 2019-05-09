using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class BinhLuanSp
    {
        [Display(Name = "Mã BL")]
        public int MaBl { get; set; }
        [Display(Name = "Nội Dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Ngày BL")]
        public DateTime? NgayBl { get; set; }
        [Display(Name = "Mã KH")]
        public int? MaKh { get; set; }
        [Display(Name = "Mã HH")]
        public int? MaHh { get; set; }
        [Display(Name = "Mã HH")]
        public HangHoa MaHhNavigation { get; set; }
        [Display(Name = "Mã KH")]
        public KhachHang MaKhNavigation { get; set; }
    }
}

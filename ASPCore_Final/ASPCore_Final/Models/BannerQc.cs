using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class BannerQc
    {
        [Display(Name = "Mã QC")]
        public int MaQc { get; set; }
        [Display(Name = "Nội Dung")]
        public string NoiDungQc { get; set; }
        [Display(Name = "Ngày Tạo")]
        public DateTime? NgayTao { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Ngày Bắt Đầu")]
        public DateTime? NgayBatDau { get; set; }
        [Display(Name = "Ngày Kết Thúc")]
        public DateTime? NgayKetThucQc { get; set; }
    }
}

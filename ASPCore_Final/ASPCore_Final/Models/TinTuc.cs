using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class TinTuc
    {
        [Display(Name = "Mã TT")]
        public int MaTt { get; set; }
        [Display(Name = "Tiêu Đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Nội Dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Ngày Tạo")]
        public DateTime? NgayTao { get; set; }
        [Display(Name = "Mã NV")]
        public int? MaNv { get; set; }
        [Display(Name = "Loại TT")]
        public string LoaiTt { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }

        [Display(Name = "Loại TT")]
        public LoaiTinTuc LoaiTtNavigation { get; set; }
        [Display(Name = "Mã NV")]
        public NhanVien MaNvNavigation { get; set; }
    }
}

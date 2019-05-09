using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class HoiDap
    {
        [Display(Name = "Mã HĐ")]
        public int MaHd { get; set; }
        [Display(Name = "Mã KH")]
        public int MaKh { get; set; }
        [Display(Name = "Mã NV")]
        public int? MaNv { get; set; }
        [Display(Name = "Câu hỏi")]
        public string CauHoi { get; set; }
        [Display(Name = "Trả lời")]
        public string TraLoi { get; set; }
        [Display(Name = "Ngày gửi")]
        public DateTime NgayDua { get; set; }
        [Display(Name = "trạng thái")]
        public bool TrangThaiTl { get; set; }
        [Display(Name = "Mã KH")]
        public KhachHang MaKhNavigation { get; set; }
        [Display(Name = "Mã NV")]
        public NhanVien MaNvNavigation { get; set; }
    }
}

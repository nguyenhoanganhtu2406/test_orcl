using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoiDap = new HashSet<HoiDap>();
            TinTuc = new HashSet<TinTuc>();
        }
        [Display(Name = "Mã NV")]
        public int MaNv { get; set; }
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }
        [Display(Name = "Mã PQ")]
        public int MaPq { get; set; }
        [Display(Name = "Trạng thái HĐ")]
        public bool? TrangThaiHd { get; set; }
        [Display(Name = "Mã PQ")]
        public PhanQuyen MaPqNavigation { get; set; }
        public ICollection<HoiDap> HoiDap { get; set; }
        public ICollection<TinTuc> TinTuc { get; set; }
    }
}

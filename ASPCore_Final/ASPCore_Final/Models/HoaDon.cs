using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHd = new HashSet<ChiTietHd>();
        }
        [Display(Name = "Mã HĐ")]
        public int MaHd { get; set; }
        [Display(Name = "Mã KH")]
        public int MaKh { get; set; }
        [Display(Name = "Ngày Đặt")]
        public DateTime NgayDat { get; set; }
        [Display(Name = "Ngày Giao")]
        public DateTime? NgayGiao { get; set; }
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "SĐT")]
        public string SdtNguoinhan { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
        [Display(Name = "Phí vận chuyển")]
        public double PhiVanChuyen { get; set; }
        [Display(Name = "Mã trạng thái")]
        public int MaTrangThai { get; set; }
        [Display(Name = "Mã NV")]
        public string MaNv { get; set; }
        [Display(Name = "Tổng tiền")]
        public double? TongTienHang { get; set; }
        [Display(Name = "Mã voucher")]
        public string MaVoucher { get; set; }
        [Display(Name = "Tổng tiền thu")]
        public double? TongThucThu { get; set; }
        [Display(Name = "Mã KH")]
        public KhachHang MaKhNavigation { get; set; }
        [Display(Name = "Mã TT")]
        public TrangThai MaTrangThaiNavigation { get; set; }
        public ICollection<ChiTietHd> ChiTietHd { get; set; }
    }
}

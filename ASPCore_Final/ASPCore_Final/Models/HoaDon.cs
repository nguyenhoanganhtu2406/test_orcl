using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethd = new HashSet<Chitiethd>();
        }
        [Display(Name = "Mã HĐ")]
        public int Mahd { get; set; }
        [Display(Name = "Mã KH")]
        public int Makh { get; set; }
        [Display(Name = "Ngày Đặt")]
        public DateTime Ngaydat { get; set; }
        [Display(Name = "Ngày Giao")]
        public DateTime? Ngaygiao { get; set; }
        [Display(Name = "Họ Tên")]
        public string Hoten { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Display(Name = "SĐT")]
        public string SdtNguoinhan { get; set; }
        [Display(Name = "Ghi chú")]
        public string Ghichu { get; set; }
        [Display(Name = "Phí vận chuyển")]
        public int Phivanchuyen { get; set; }
        [Display(Name = "Mã trạng thái")]
        public int? Matrangthai { get; set; }
        [Display(Name = "Mã NV")]
        public int? Manv { get; set; }
        [Display(Name = "Tổng tiền")]
        public decimal? Tongtienhang { get; set; }
        [Display(Name = "Tổng tiền thu")]
        public decimal? Tongthucthu { get; set; }
        [Display(Name = "Mã KH")]
        public Khachhang MakhNavigation { get; set; }
        [Display(Name = "Mã TT")]
        public Trangthai MatrangthaiNavigation { get; set; }
        public ICollection<Chitiethd> Chitiethd { get; set; }
    }
}

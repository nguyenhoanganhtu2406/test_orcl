using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class Voucher
    {
        [Display(Name = "Mã VC")]
        public string MaVc { get; set; }
        [Display(Name = "Nội Dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? NgayTao { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        public DateTime? NgayBatDau { get; set; }
        [Display(Name = "Ngày hết hạn")]
        public DateTime? NgayHetHan { get; set; }
        [Display(Name = "Giảm giá")]
        public double? GiamGia { get; set; }
        [Display(Name = "Tổng tiền đ.ký")]
        public long? TongTienDk { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? TrangThai { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class HangHoa
    {
        public HangHoa()
        {
            BinhLuanSp = new HashSet<BinhLuanSp>();
            ChiTietHd = new HashSet<ChiTietHd>();
            ChiTietPhieuNhap = new HashSet<ChiTietPhieuNhap>();
            SanPhamKhoNavigation = new HashSet<SanPhamKho>();
            YeuThich = new HashSet<YeuThich>();
        }
        [Display(Name = "Mã HH")]
        public int MaHh { get; set; }
        [Display(Name = "Tên HH")]
        public string TenHh { get; set; }
        [Display(Name = "Mã Loại")]
        public string MaLoai { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Đơn Giá")]
        public double DonGia { get; set; }
        [Display(Name = "Giảm Giá")]
        public double GiamGia { get; set; }
        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }
        [Display(Name = "Mã NCC")]
        public string MaNcc { get; set; }
        [Display(Name = "SP kho")]
        public int? SanPhamKho { get; set; }
        [Display(Name = "Mã Loại")]
        public Loai MaLoaiNavigation { get; set; }
        [Display(Name = "Mã NCC")]
        public NhaCungCap MaNccNavigation { get; set; }
        public ICollection<BinhLuanSp> BinhLuanSp { get; set; }
        public ICollection<ChiTietHd> ChiTietHd { get; set; }
        public ICollection<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public ICollection<SanPhamKho> SanPhamKhoNavigation { get; set; }
        public ICollection<YeuThich> YeuThich { get; set; }
    }
}

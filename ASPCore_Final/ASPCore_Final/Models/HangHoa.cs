using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class Hanghoa
    {
        public Hanghoa()
        {
            Chitiethd = new HashSet<Chitiethd>();
            Sanphamkho = new HashSet<Sanphamkho>();
        }
        [Display(Name = "Mã HH")]
        public int Mahh { get; set; }
        [Display(Name = "Tên HH")]
        public string Tenhh { get; set; }
        [Display(Name = "Mã Loại")]
        public string Maloai { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Đơn Giá")]
        public decimal Dongia { get; set; }
        [Display(Name = "Giảm Giá")]
        public decimal Giamgia { get; set; }
        [Display(Name = "Mô Tả")]
        public string Mota { get; set; }
        [Display(Name = "Mã NCC")]
        public string Mancc { get; set; }
        [Display(Name = "Mã Loại")]
        public Loai MaloaiNavigation { get; set; }
        [Display(Name = "Mã NCC")]
        public Nhacungcap ManccNavigation { get; set; }
        public ICollection<Chitiethd> Chitiethd { get; set; }
        public ICollection<Sanphamkho> Sanphamkho { get; set; }
    }
}

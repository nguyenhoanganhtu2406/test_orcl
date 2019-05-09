using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethd = new HashSet<Chitiethd>();
        }

        public int Mahd { get; set; }
        public int Makh { get; set; }
        public DateTime Ngaydat { get; set; }
        public DateTime? Ngaygiao { get; set; }
        public string Hoten { get; set; }
        public string Diachi { get; set; }
        public string SdtNguoinhan { get; set; }
        public string Ghichu { get; set; }
        public int Phivanchuyen { get; set; }
        public int? Matrangthai { get; set; }
        public int? Manv { get; set; }
        public decimal? Tongtienhang { get; set; }
        public decimal? Tongthucthu { get; set; }

        public Khachhang MakhNavigation { get; set; }
        public Trangthai MatrangthaiNavigation { get; set; }
        public ICollection<Chitiethd> Chitiethd { get; set; }
    }
}

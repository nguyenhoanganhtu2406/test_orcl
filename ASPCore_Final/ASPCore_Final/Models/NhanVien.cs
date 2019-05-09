using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Nhanvien
    {
        public int Manv { get; set; }
        public string Hoten { get; set; }
        public string Email { get; set; }
        public string Matkhau { get; set; }
        public int Mapq { get; set; }
        public bool? Trangthaihd { get; set; }

        public Phanquyen MapqNavigation { get; set; }
    }
}

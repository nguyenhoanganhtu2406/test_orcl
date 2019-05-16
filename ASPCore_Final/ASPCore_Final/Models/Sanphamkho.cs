using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Sanphamkho
    {
        public int MaspKho { get; set; }
        public int Mahh { get; set; }
        public string Kichco { get; set; }
        public int? Soluong { get; set; }

        public Hanghoa MahhNavigation { get; set; }
    }
}

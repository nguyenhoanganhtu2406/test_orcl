using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Chitiethd
    {
        public int Mact { get; set; }
        public int Mahd { get; set; }
        public int Mahh { get; set; }
        public decimal Dongia { get; set; }
        public decimal? Giamgia { get; set; }
        public int Soluong { get; set; }
        public string Kichco { get; set; }

        public Hoadon MahdNavigation { get; set; }
        public Hanghoa MahhNavigation { get; set; }
    }
}

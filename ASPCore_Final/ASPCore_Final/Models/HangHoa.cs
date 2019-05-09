using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Hanghoa
    {
        public Hanghoa()
        {
            Chitiethd = new HashSet<Chitiethd>();
        }

        public int Mahh { get; set; }
        public string Tenhh { get; set; }
        public string Maloai { get; set; }
        public string Hinh { get; set; }
        public decimal Dongia { get; set; }
        public decimal Giamgia { get; set; }
        public string Mota { get; set; }
        public string Mancc { get; set; }

        public Loai MaloaiNavigation { get; set; }
        public Nhacungcap ManccNavigation { get; set; }
        public ICollection<Chitiethd> Chitiethd { get; set; }
    }
}

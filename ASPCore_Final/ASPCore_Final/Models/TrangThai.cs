using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Trangthai
    {
        public Trangthai()
        {
            Hoadon = new HashSet<Hoadon>();
        }

        public int Matrangthai { get; set; }
        public string Tentrangthai { get; set; }

        public ICollection<Hoadon> Hoadon { get; set; }
    }
}

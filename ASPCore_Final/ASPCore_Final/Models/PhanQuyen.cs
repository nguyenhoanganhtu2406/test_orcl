using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Phanquyen
    {
        public Phanquyen()
        {
            Nhanvien = new HashSet<Nhanvien>();
        }

        public int Mapq { get; set; }
        public bool Them { get; set; }
        public bool Sua { get; set; }
        public bool Xoa { get; set; }
        public bool Xem { get; set; }

        public ICollection<Nhanvien> Nhanvien { get; set; }
    }
}

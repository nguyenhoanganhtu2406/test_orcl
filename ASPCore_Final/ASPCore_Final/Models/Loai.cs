using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Loai
    {
        public Loai()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }

        public string Maloai { get; set; }
        public bool Gioitinh { get; set; }
        public string Tenloai { get; set; }

        public ICollection<Hanghoa> Hanghoa { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ASPCore_Final.Models
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }

        public string Mancc { get; set; }
        public string Tencongty { get; set; }
        public string Email { get; set; }
        public string Dienthoai { get; set; }
        public string Diachi { get; set; }

        public ICollection<Hanghoa> Hanghoa { get; set; }
    }
}

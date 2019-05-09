using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class Loai
    {
        public Loai()
        {
            HangHoa = new HashSet<HangHoa>();
        }
        [Display(Name = "Mã Loại")]
        public string MaLoai { get; set; }
        [Display(Name = "Giới Tính")]
        public bool GioiTinh { get; set; }
        [Display(Name = "Tên Loại")]
        public string TenLoai { get; set; }

        public ICollection<HangHoa> HangHoa { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class Loai
    {
        public Loai()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }
        [Display(Name = "Mã loại")]
        public string Maloai { get; set; }
        [Display(Name = "Giới tính")]
        public bool Gioitinh { get; set; }
        [Display(Name = "Tên loại")]
        public string Tenloai { get; set; }

        public ICollection<Hanghoa> Hanghoa { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class LoaiTinTuc
    {
        public LoaiTinTuc()
        {
            TinTuc = new HashSet<TinTuc>();
        }
        [Display(Name = "Mã Loại TT")]
        public string LoaiTt { get; set; }
        [Display(Name = "Tên TT")]
        public string TenTt { get; set; }

        public ICollection<TinTuc> TinTuc { get; set; }
    }
}

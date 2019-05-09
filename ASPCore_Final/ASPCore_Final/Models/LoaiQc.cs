using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPCore_Final.Models
{
    public partial class LoaiQc
    {
        public LoaiQc()
        {
            BannerQc = new HashSet<BannerQc>();
        }
        [Display(Name = "Mã Loại QC")]
        public string LoaiQc1 { get; set; }
        [Display(Name = "Tên QC")]
        public string TenQc { get; set; }

        public ICollection<BannerQc> BannerQc { get; set; }
    }
}

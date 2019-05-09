using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCore_Final.Models
{
    public class CartItem
    {
        [Display(Name = "Mã HH")]
        public int MaHh { get; set; }
        [Display(Name = "Tên HH")]
        public string TenHh { get; set; }
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [Display(Name = "Kich Cỡ")]
        public string KichCo { get; set; }
        [Display(Name = "Giá Bán")]
        public double GiaBan { get; set; }
        [Display(Name = "Số Lượng")]
        public int SoLuong { get; set; }
   
        public double ThanhTien => GiaBan * SoLuong;
    }
}

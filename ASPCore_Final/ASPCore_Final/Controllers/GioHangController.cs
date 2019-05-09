using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ASPCore_Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore_Final.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ModelContext db;
        public GioHangController(ModelContext ctx)
        {
            db = ctx;
        }
        public IActionResult Index()
        {
            return View(Carts);
        }

        public List<CartItem> Carts
        {
            get
            {
                List<CartItem> myCart = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (myCart == default(List<CartItem>))
                {
                    myCart = new List<CartItem>();
                }

                return myCart;
            }
        }
        [HttpPost]
        public IActionResult AddToCart(int mahh,string size, int soluongsp)
        {
            if (HttpContext.Session.Get<string>("mess") != null)
                HttpContext.Session.Remove("mess");
            List<CartItem> gioHang = Carts;
            //tìm xem có chưa
            CartItem item = gioHang.SingleOrDefault(p => p.MaHh == mahh && p.KichCo == size);
            if (item != null) //có rồi
            {
                item.SoLuong++;
            }
            else
            {
                Hanghoa hh = db.Hanghoa.SingleOrDefault(p => p.Mahh == mahh);
                item = new CartItem
                {
                    MaHh = hh.Mahh,
                    TenHh = hh.Tenhh,
                    Hinh = hh.Hinh,
                    SoLuong = soluongsp,
                    KichCo = size,
                    GiaBan = Convert.ToDouble(hh.Dongia * (1 - hh.Giamgia))
                };
                gioHang.Add(item);
            }
            //lưu session
            HttpContext.Session.Set("GioHang", gioHang);
            return RedirectToAction("Index");
        }

        public IActionResult XoaCartItem(int cartitemhh, string cartitemkichco)
        {
            List<CartItem> giohang = Carts;
            // lấy hang hóa muốn xóa
            CartItem hh = giohang.SingleOrDefault(p => p.MaHh == cartitemhh && p.KichCo == cartitemkichco);
            giohang.Remove(hh);
            HttpContext.Session.Set("GioHang", giohang);
            return RedirectToAction("Index");
        }

      
        public List<CartItem> CapNhatSL(string mahh, string kichco, string soluongmoi)
        {
            List<CartItem> giohang = Carts;
            CartItem hh = giohang.SingleOrDefault(p => p.MaHh == Int32.Parse(mahh) && p.KichCo == kichco);
            hh.SoLuong = Int32.Parse(soluongmoi);
            HttpContext.Session.Set("GioHang", giohang);
            return giohang;
        }
        public IActionResult TaoHoaDonBT(string email,string hoten_ngnhan, string dc_nguoinhan, string ghichu, string sdt, string magiamgia)
        {

            Khachhang kh = new Khachhang();
            kh.Hoten = hoten_ngnhan;
            kh.Diachi = dc_nguoinhan;
            kh.Dienthoai = sdt;

            kh.Email = email;
            db.Khachhang.Add(kh);
            db.SaveChanges();
            // tạo hóa đơn
            var getKH = db.Khachhang.Where(p => p.Email == email).OrderByDescending(p => p.Makh).Take(1); 
            foreach(var titem in getKH)
            {
                Hoadon hd = new Hoadon
                {
                    Makh = titem.Makh,
                    Hoten = hoten_ngnhan,
                    Diachi = dc_nguoinhan,
                    Ngaydat = DateTime.Now,
                    Ghichu = ghichu,
                    SdtNguoinhan = sdt,
                    Matrangthai = 0,
                    Phivanchuyen = 35000
                };
                db.Hoadon.Add(hd);
                // tạo chi tiết hóa đơn
                //  double tt = 0;
                double tongtienhang = 0;
                double tongthucthu = 0;

                foreach (var item in Carts)
                {
                    tongtienhang += item.ThanhTien;
                    Hanghoa hh = db.Hanghoa.SingleOrDefault(p => p.Mahh == item.MaHh);
                    //   tt = item.SoLuong * hh.DonGia * (1 - hh.GiamGia);
                    Chitiethd cthd = new Chitiethd
                    {
                        Mahd = hd.Mahd,
                        Mahh = item.MaHh,
                        Dongia = hh.Dongia,
                        Giamgia = hh.Giamgia,
                        Soluong = item.SoLuong,
                        Kichco = item.KichCo
                    };

                    db.Chitiethd.Add(cthd);
                    db.SaveChanges();
                    
                }
                hd.Tongtienhang = Convert.ToDecimal(tongtienhang);
                hd.Tongthucthu = Convert.ToDecimal(tongthucthu);
                db.SaveChanges();
                HttpContext.Session.Set<string>("mess", "Hóa đơn của bạn đã được gửi tới cửa hàng vui lòng chờ kiểm tra mail để biết trạng thái đơn hàng của bạn . ESHOP");
                HttpContext.Session.Remove("GioHang");
                
            }

            return RedirectToAction("Index");


        }

        public IActionResult TaoHoaDon(int makh,string hotenkh,string diachi,string hoten_ngnhan,string dc_nguoinhan,string ghichu,string sdt,string magiamgia)
        {
            // tạo hóa đơn
            Hoadon hd = new Hoadon
            {
                Makh = makh,
                Hoten = hoten_ngnhan,
                Diachi = dc_nguoinhan,
                Ngaydat = DateTime.Now,
                Ghichu = ghichu,
                SdtNguoinhan = sdt,
                Matrangthai = 0,
                Phivanchuyen = 35000
            };
            
            db.Hoadon.Add(hd);
            // tạo chi tiết hóa đơn
            //  double tt = 0;
            double tongtienhang = 0;
            double tongthucthu = 0;
            Khachhang kh = db.Khachhang.SingleOrDefault(p => p.Makh == makh);
            foreach (var item in Carts)
            {
                tongtienhang += item.ThanhTien;
                Hanghoa hh = db.Hanghoa.SingleOrDefault(p => p.Mahh == item.MaHh);
             //   tt = item.SoLuong * hh.DonGia * (1 - hh.GiamGia);
                Chitiethd cthd = new Chitiethd
                {
                    Mahd = hd.Mahd,
                    Mahh = item.MaHh,
                    Dongia = hh.Dongia,
                    Giamgia = hh.Giamgia,
                    Soluong = item.SoLuong,
                    Kichco = item.KichCo
                };
              
                db.Chitiethd.Add(cthd);
                db.SaveChanges();
            }
            hd.Tongtienhang = Convert.ToDecimal(tongtienhang);
            hd.Tongthucthu = Convert.ToDecimal(tongthucthu);
            db.SaveChanges();
            HttpContext.Session.Set<string>("mess", "Hóa đơn của bạn đã được gửi tới cửa hàng vui lòng chờ kiểm tra mail để biết trạng thái đơn hàng của bạn . ESHOP");
            HttpContext.Session.Remove("GioHang");
            return RedirectToAction("Index");
        }

        public IActionResult HoaDon()
        {
            return View();
        }
    }
}
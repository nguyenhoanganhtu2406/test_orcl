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
        private readonly ESHOPContext db;
        public GioHangController(ESHOPContext ctx)
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
                HangHoa hh = db.HangHoa.SingleOrDefault(p => p.MaHh == mahh);
                item = new CartItem
                {
                    MaHh = hh.MaHh,
                    TenHh = hh.TenHh,
                    Hinh = hh.Hinh,
                    SoLuong = soluongsp,
                    KichCo = size,
                    GiaBan = hh.DonGia * (1 - hh.GiamGia)
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

            KhachHang kh = new KhachHang();
            kh.HoTen = hoten_ngnhan;
            kh.DiaChi = dc_nguoinhan;
            kh.DienThoai = sdt;

            kh.Email = email;
            db.KhachHang.Add(kh);
            db.SaveChanges();
            // tạo hóa đơn
            var getKH = db.KhachHang.Where(p => p.Email == email).OrderByDescending(p => p.MaKh).Take(1); 
            foreach(var titem in getKH)
            {
                HoaDon hd = new HoaDon
                {
                    MaKh = titem.MaKh,
                    HoTen = hoten_ngnhan,
                    DiaChi = dc_nguoinhan,
                    NgayDat = DateTime.Now,
                    GhiChu = ghichu,
                    SdtNguoinhan = sdt,
                    MaTrangThai = 0,
                    PhiVanChuyen = 35000,
                    MaVoucher = magiamgia
                };
                db.HoaDon.Add(hd);
                // tạo chi tiết hóa đơn
                //  double tt = 0;
                double tongtienhang = 0;
                double tongthucthu = 0;

                foreach (var item in Carts)
                {
                    tongtienhang += item.ThanhTien;
                    HangHoa hh = db.HangHoa.SingleOrDefault(p => p.MaHh == item.MaHh);
                    //   tt = item.SoLuong * hh.DonGia * (1 - hh.GiamGia);
                    ChiTietHd cthd = new ChiTietHd
                    {
                        MaHd = hd.MaHd,
                        MaHh = item.MaHh,
                        DonGia = hh.DonGia,
                        GiamGia = hh.GiamGia,
                        SoLuong = item.SoLuong,
                        KichCo = item.KichCo
                    };

                    db.ChiTietHd.Add(cthd);
                    db.SaveChanges();
                    // trừ sản phẩm từ kho
                    SanPhamKho spk = db.SanPhamKho.SingleOrDefault(p => p.MaHh == cthd.MaHh && p.KichCo == cthd.KichCo);
                    if (spk.SoLuong >= cthd.SoLuong)
                    {
                        if (HttpContext.Session.Get<string>("ErrorGH") != null)
                        {
                            HttpContext.Session.Remove("ErrorGH");
                        }
                        spk.SoLuong = spk.SoLuong - cthd.SoLuong;
                    }
                    else
                    {
                        HangHoa hangHoa = db.HangHoa.SingleOrDefault(p => p.MaHh == cthd.MaHh);
                        string loi = "Hàng hóa có mã " + hangHoa.TenHh + " chỉ còn : " + spk.SoLuong + " sản phẩm";
                        HttpContext.Session.Set("ErrorGH", loi);
                        db.ChiTietHd.Remove(cthd);
                        db.HoaDon.Remove(hd);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                Voucher v = db.Voucher.Find(magiamgia);
                if (v != null)
                {
                    tongthucthu = tongtienhang + 35000 - Convert.ToDouble(tongtienhang * v.GiamGia);
                }
                else
                {
                    tongthucthu = tongtienhang + 35000;
                }
                hd.TongTienHang = tongtienhang;
                hd.TongThucThu = tongthucthu;
                db.SaveChanges();
                HttpContext.Session.Set<string>("mess", "Hóa đơn của bạn đã được gửi tới cửa hàng vui lòng chờ kiểm tra mail để biết trạng thái đơn hàng của bạn . ESHOP");
                HttpContext.Session.Remove("GioHang");
                
            }

            return RedirectToAction("Index");


        }

        public IActionResult TaoHoaDon(int makh,string hotenkh,string diachi,string hoten_ngnhan,string dc_nguoinhan,string ghichu,string sdt,string magiamgia)
        {
            // tạo hóa đơn
            HoaDon hd = new HoaDon
            {
                MaKh = makh,
                HoTen = hoten_ngnhan,
                DiaChi = dc_nguoinhan,
                NgayDat = DateTime.Now,
                GhiChu = ghichu,
                SdtNguoinhan = sdt,
                MaTrangThai = 0,
                PhiVanChuyen = 35000,
                MaVoucher = magiamgia
            };
            
            db.HoaDon.Add(hd);
            // tạo chi tiết hóa đơn
            //  double tt = 0;
            double tongtienhang = 0;
            double tongthucthu = 0;
            KhachHang kh = db.KhachHang.SingleOrDefault(p => p.MaKh == makh);
            foreach (var item in Carts)
            {
                tongtienhang += item.ThanhTien;
                HangHoa hh = db.HangHoa.SingleOrDefault(p => p.MaHh == item.MaHh);
             //   tt = item.SoLuong * hh.DonGia * (1 - hh.GiamGia);
                ChiTietHd cthd = new ChiTietHd
                {
                    MaHd = hd.MaHd,
                    MaHh = item.MaHh,
                    DonGia = hh.DonGia,
                    GiamGia = hh.GiamGia,
                    SoLuong = item.SoLuong,
                    KichCo = item.KichCo
                };
              
                db.ChiTietHd.Add(cthd);
                db.SaveChanges();
                // trừ sản phẩm từ kho
                SanPhamKho spk = db.SanPhamKho.SingleOrDefault(p => p.MaHh == cthd.MaHh && p.KichCo == cthd.KichCo);
                if(spk.SoLuong >= cthd.SoLuong)
                {
                    if (HttpContext.Session.Get<string>("ErrorGH") != null)
                    {
                        HttpContext.Session.Remove("ErrorGH");
                    }
                    spk.SoLuong = spk.SoLuong - cthd.SoLuong;
                }
                else
                {
                    HangHoa hangHoa = db.HangHoa.SingleOrDefault(p => p.MaHh == cthd.MaHh);
                    string loi = "Hàng hóa có mã " + hangHoa.TenHh + " chỉ còn : " + spk.SoLuong + " sản phẩm";
                    HttpContext.Session.Set("ErrorGH",loi);
                    db.ChiTietHd.Remove(cthd);
                    db.HoaDon.Remove(hd);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            Voucher v = db.Voucher.Find(magiamgia);
            if(v != null)
            {
                tongthucthu = tongtienhang + 35000 - Convert.ToDouble(tongtienhang * v.GiamGia);
            }
            else
            {
                tongthucthu = tongtienhang + 35000;
            }
            hd.TongTienHang = tongtienhang;
            hd.TongThucThu = tongthucthu;
            db.SaveChanges();
            HttpContext.Session.Set<string>("mess", "Hóa đơn của bạn đã được gửi tới cửa hàng vui lòng chờ kiểm tra mail để biết trạng thái đơn hàng của bạn . ESHOP");
            HttpContext.Session.Remove("GioHang");
            return RedirectToAction("Index");
        }

        public IActionResult HoaDon()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckVoucher(string magiamgia,double tongtien)
        {
            Voucher v = db.Voucher.SingleOrDefault(p=>p.TrangThai == true && p.NgayHetHan >= DateTime.Now && p.MaVc == magiamgia);
            if(v != null)
            {
                if(v.NgayHetHan >= DateTime.Now)
                {
                    if (tongtien >= v.TongTienDk)
                    {

                        double tiengiam = Convert.ToDouble(tongtien * v.GiamGia);
                        HttpContext.Session.Set("SoTienGiam", tiengiam);
                        HttpContext.Session.Set("PhanTramGiam", v.GiamGia);
                        HttpContext.Session.Set("mavc", magiamgia);
                        HttpContext.Session.Remove("voucherIf");
                    }
                    else
                    {
                        HttpContext.Session.Set("voucherIf", "Mã voucher không áp dụng với đơn hàng dưới " + Convert.ToDouble(v.TongTienDk).ToString("#,##0") + "đ");
                        HttpContext.Session.Set("mavc", magiamgia);
                    }
                }
                else
                {
                    HttpContext.Session.Set("voucherIf", "Mã voucher đã hết hạn");
                    HttpContext.Session.Set("mavc", magiamgia);
                }
            }
            else
            {
                HttpContext.Session.Set("voucherIf", "Mã voucher không tồn tại");
                HttpContext.Session.Set("mavc", magiamgia);
            }
            return RedirectToAction("Index");
        }
    }
}
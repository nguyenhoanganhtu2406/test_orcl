using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ASPCore_Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore_Final.Controllers
{
    [Area("Admin")]
    public class VoucherController : Controller
    {
        private readonly ESHOPContext db;
        public VoucherController(ESHOPContext ctx)
        {
            db = ctx;
        }

        [HttpGet("/admin/Voucher")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/admin/Voucher/GuiVoucher")]
        public IActionResult GuiVoucher(string mavc)
        {
            Voucher voucher = db.Voucher.SingleOrDefault(p => p.MaVc == mavc);
            voucher.TrangThai = true;
            double giamgia = Convert.ToDouble(voucher.GiamGia * 100);
            List<KhachHang> khachHangs = db.KhachHang.ToList();
            foreach (var item in khachHangs)
            {
                MailMessage mm = new MailMessage("eshoppingmanager@gmail.com", item.Email);
                string content = "";
                content = content + "<h2>Chào mừng bạn đến với ESHOP.</h2>";
                content = content + "<h2>Nhân dịp "+voucher.NoiDung+" chúng tôi gửi đến bạn một mã voucher. Giảm giá "+giamgia+"% với đơn hàng trên "+@Convert.ToDouble(voucher.TongTienDk).ToString("#,##0")+"đ</h2><br>";
                content = content + "<h1 style='color:blue'>" + voucher.MaVc + "</h1>";
                content = content + "<div>Cảm ơn bạn đã ủng hộ ESHOP. Thân</div>";
                mm.Body = string.Format(content, item.HoTen);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("eshoppingmanager@gmail.com", "eshop147258369");
                smtp.Send(mm);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/admin/Voucher/TaoVoucher")]
        public IActionResult TaoVoucher()
        {
            return View();
        }

        public string CreateVoucher(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        [HttpPost]
        public IActionResult TaoVoucher(Voucher vc)
        {
            if (ModelState.IsValid)
            {
                Voucher v = new Voucher
                {
                    MaVc = CreateVoucher(10),
                    NoiDung = vc.NoiDung,
                    NgayTao = DateTime.Now,
                    GiamGia = vc.GiamGia,
                    TongTienDk = vc.TongTienDk,
                    TrangThai = false
                };
                if(vc.NgayBatDau > vc.NgayHetHan)
                {
                    HttpContext.Session.Set("loi", "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày hết hạn");
                    return RedirectToAction("TaoVoucher");
                }
                else
                {
                    v.NgayBatDau = vc.NgayBatDau;
                    v.NgayHetHan = vc.NgayHetHan;
                    db.Voucher.Add(v);
                    db.SaveChanges();
                    HttpContext.Session.Remove("loi");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet("/admin/Voucher/Xoa")]
        public IActionResult Xoa(string mavc)
        {
            Voucher voucher = db.Voucher.Find(mavc);
            db.Voucher.Remove(voucher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/admin/Voucher/Sua")]
        public IActionResult Sua(string mavc)
        {
            Voucher vc = db.Voucher.Find(mavc);
            return View(vc);
        }

        [HttpPost]
        public IActionResult Sua(Voucher v)
        {
            Voucher vc = db.Voucher.Find(v.MaVc);
            vc.NoiDung = v.NoiDung;
            vc.NgayBatDau = v.NgayBatDau;
            vc.NgayHetHan = v.NgayHetHan;
            vc.TongTienDk = v.TongTienDk;
            if (vc.NgayBatDau > vc.NgayHetHan)
            {
                HttpContext.Session.Set("loi", "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày hết hạn");
                return RedirectToAction("Sua",v);
            }
            else
            {
                db.SaveChanges();
                HttpContext.Session.Remove("loi");
            }
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCore_Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore_Final.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly ESHOPContext db;
        public HangHoaController(ESHOPContext ctx)
        {
            db = ctx;
        }

        
        public IActionResult Index(string loai="", bool? gioitinh = null, int page = 1, int pageSize = 6)
        {
            int starIndex = (page - 1) * pageSize;
            List<HangHoa> hangHoas =  db.HangHoa.Skip(starIndex).ToList();
            if (gioitinh != null)
            {
                hangHoas = db.HangHoa.Where(p => p.MaLoaiNavigation.GioiTinh == gioitinh).Skip(starIndex).ToList();
            }
            else if(loai != null && loai != "")
            {
                hangHoas = db.HangHoa.Where(p => p.MaLoai == loai).Skip(starIndex).ToList();
            }
            int itemsize = hangHoas.Count < pageSize ? hangHoas.Count : pageSize;
            List<HangHoa> res = hangHoas.Take(itemsize).ToList();
            ViewData["TongSoLuong"] = hangHoas.Count;
            return View("Index",res);
        }

        public IActionResult TaiThem(string loai = "", bool? gioitinh = null, string mucgia = "", string sapxep = "", int page = 2, int pageSize = 6)
        {
            int starIndex = (page - 1) * pageSize;

            List<HangHoa> hangHoas = db.HangHoa.ToList();
            List<HangHoaBanChayModel> hangHoaBanChays = new List<HangHoaBanChayModel>();
            if (gioitinh != null)
            {
                hangHoas = db.HangHoa.Where(p => p.MaLoaiNavigation.GioiTinh == gioitinh).ToList();
            }
            else if (loai != null && loai != "")
            {
                hangHoas = db.HangHoa.Where(p => p.MaLoai == loai).ToList();
            }
            switch (mucgia)
            {
                case "100000":
                    hangHoas = hangHoas.Where(p => p.DonGia * (1 - p.GiamGia) < 100000).ToList();
                    break;
                case "200000":
                    hangHoas = hangHoas.Where(p => p.DonGia * (1 - p.GiamGia) >= 100000 && p.DonGia * (1 - p.GiamGia) < 200000).ToList();
                    break;
                case "300000":
                    hangHoas = hangHoas.Where(p => p.DonGia * (1 - p.GiamGia) >= 200000 && p.DonGia * (1 - p.GiamGia) < 300000).ToList();
                    break;
                default:
                    break;
            }
            switch (sapxep)
            {
                case "tang":
                    hangHoas = hangHoas.OrderBy(p => p.DonGia * (1 - p.GiamGia)).ToList();
                    break;
                case "giam":
                    hangHoas = hangHoas.OrderByDescending(p => p.DonGia * (1 - p.GiamGia)).ToList();
                    break;
                case "moinhat":
                    hangHoas = hangHoas.OrderByDescending(p => p.MaHh).ToList();
                    break;
                case "banchay":
                    hangHoaBanChays = hangHoas.Join(db.ChiTietHd,
                                             hh => hh.MaHh,
                                             cthd => cthd.MaHh,
                                             (hh, cthd) => new { HHoa = hh, CTiet = cthd })
                                       .Join(db.HoaDon.Where(hd => (DateTime.Now - hd.NgayDat).TotalDays <= 30),
                                             hhcthd => hhcthd.CTiet.MaHd,
                                             hd => hd.MaHd,
                                             (hhcthd, hd) => new { HHCTHD = hhcthd, HDon = hd })
                                       .GroupBy(g => new { g.HHCTHD.HHoa.MaHh, g.HHCTHD.HHoa.TenHh, g.HHCTHD.HHoa.Hinh, g.HHCTHD.HHoa.MoTa, g.HHCTHD.HHoa.DonGia, g.HHCTHD.HHoa.GiamGia })
                                       .OrderByDescending(g => g.Sum(t => t.HHCTHD.CTiet.SoLuong))
                                       .Select(group => new HangHoaBanChayModel
                                       {
                                            MaHH = group.Key.MaHh,
                                            TenHH = group.Key.TenHh,
                                            HAnh = group.Key.Hinh,
                                            MTa = group.Key.MoTa,
                                            DGIa = group.Key.DonGia,
                                            GGia = group.Key.GiamGia,
                                            TongSoBan = group.Sum(t => t.HHCTHD.CTiet.SoLuong)
                                        }).ToList();
                    //var hhbc = from hh in hangHoas
                    //           join cthd in db.ChiTietHd on hh.MaHh equals cthd.MaHh
                    //           join hd in db.HoaDon on cthd.MaHd equals hd.MaHd
                    //           group 
                    break;
                default:
                    break;
            }
            if(sapxep == "banchay")
            {
                hangHoaBanChays = hangHoaBanChays.Skip(starIndex).ToList();
                int itemsize = hangHoaBanChays.Count < pageSize ? hangHoaBanChays.Count : pageSize;
                List<HangHoaBanChayModel> res = hangHoaBanChays.Take(itemsize).ToList();
                ViewData["TongSoLuong"] = hangHoaBanChays.Count;
                return PartialView("TaiThemBanChay", res);
            }
            else
            {
                hangHoas = hangHoas.Skip(starIndex).ToList();
                int itemsize = hangHoas.Count < pageSize ? hangHoas.Count : pageSize;
                List<HangHoa> res = hangHoas.Take(itemsize).ToList();
                ViewData["TongSoLuong"] = hangHoas.Count;
                return PartialView(res);
            }
        }

        public IActionResult Filter(string loai = "", bool? gioitinh = null, string mucgia = "", string sapxep = "", int page = 1, int pageSize = 6)
        {
            int starIndex = (page - 1) * pageSize;

            List<HangHoa> hangHoas = db.HangHoa.ToList();
            List<HangHoaBanChayModel> hangHoaBanChays = new List<HangHoaBanChayModel>();
            if (gioitinh != null)
            {
                hangHoas = db.HangHoa.Where(p => p.MaLoaiNavigation.GioiTinh == gioitinh).ToList();
            }
            else if (loai != null && loai != "")
            {
                hangHoas = db.HangHoa.Where(p => p.MaLoai == loai).ToList();
            }
            switch (mucgia)
            {
                case "100000":
                    hangHoas = hangHoas.Where(p => p.DonGia * (1 - p.GiamGia) < 100000).ToList();
                    break;
                case "200000":
                    hangHoas = hangHoas.Where(p => p.DonGia * (1 - p.GiamGia) >= 100000 && p.DonGia * (1 - p.GiamGia) < 200000).ToList();
                    break;
                case "300000":
                    hangHoas = hangHoas.Where(p => p.DonGia * (1 - p.GiamGia) >= 200000 && p.DonGia * (1 - p.GiamGia) < 300000).ToList();
                    break;
                default:
                    break;
            }
            switch (sapxep)
            {
                case "tang":
                    hangHoas = hangHoas.OrderBy(p => p.DonGia * (1 - p.GiamGia)).ToList();
                    break;
                case "giam":
                    hangHoas = hangHoas.OrderByDescending(p => p.DonGia * (1 - p.GiamGia)).ToList();
                    break;
                case "moinhat":
                    hangHoas = hangHoas.OrderByDescending(p => p.MaHh).ToList();
                    break;
                case "banchay":
                    hangHoaBanChays = hangHoas.Join(db.ChiTietHd,
                                             hh => hh.MaHh,
                                             cthd => cthd.MaHh,
                                             (hh, cthd) => new { HHoa = hh, CTiet = cthd })
                                       .Join(db.HoaDon.Where(hd => (DateTime.Now - hd.NgayDat).TotalDays <= 30),
                                             hhcthd => hhcthd.CTiet.MaHd,
                                             hd => hd.MaHd,
                                             (hhcthd, hd) => new { HHCTHD = hhcthd, HDon = hd })
                                       .GroupBy(g => new { g.HHCTHD.HHoa.MaHh, g.HHCTHD.HHoa.TenHh, g.HHCTHD.HHoa.Hinh, g.HHCTHD.HHoa.MoTa, g.HHCTHD.HHoa.DonGia, g.HHCTHD.HHoa.GiamGia })
                                       .OrderByDescending(g => g.Sum(t => t.HHCTHD.CTiet.SoLuong))
                                       .Select(group => new HangHoaBanChayModel
                                       {
                                           MaHH = group.Key.MaHh,
                                           TenHH = group.Key.TenHh,
                                           HAnh = group.Key.Hinh,
                                           MTa = group.Key.MoTa,
                                           DGIa = group.Key.DonGia,
                                           GGia = group.Key.GiamGia,
                                           TongSoBan = group.Sum(t => t.HHCTHD.CTiet.SoLuong)
                                       }).ToList();
                    //var hhbc = from hh in hangHoas
                    //           join cthd in db.ChiTietHd on hh.MaHh equals cthd.MaHh
                    //           join hd in db.HoaDon on cthd.MaHd equals hd.MaHd
                    //           group 
                    break;
                default:
                    break;
            }
            if (sapxep == "banchay")
            {
                hangHoaBanChays = hangHoaBanChays.Skip(starIndex).ToList();
                int itemsize = hangHoaBanChays.Count < pageSize ? hangHoaBanChays.Count : pageSize;
                List<HangHoaBanChayModel> res = hangHoaBanChays.Take(itemsize).ToList();
                ViewData["TongSoLuong"] = hangHoaBanChays.Count;
                return PartialView("FilterBanChay", res);
            }
            else
            {
                hangHoas = hangHoas.Skip(starIndex).ToList();
                int itemsize = hangHoas.Count < pageSize ? hangHoas.Count : pageSize;
                List<HangHoa> res = hangHoas.Take(itemsize).ToList();
                ViewData["TongSoLuong"] = hangHoas.Count;
                return PartialView(res);
            }
        }

        public IActionResult ChiTiet(int mahh)
        {
            HangHoa hh = db.HangHoa.SingleOrDefault(p => p.MaHh == mahh);
            return View(hh);
        }

        public IActionResult TimKiem(string keyword)
        {
            List<HangHoa> hh = new List<HangHoa>();
            if(keyword != null)
            {
                hh = db.HangHoa.Where(p => p.TenHh.ToLower().Contains(keyword.ToLower())).Take(6).ToList();
            }
            return View(hh);
        }

        public IActionResult ThemDanhGia(int mahh,string noidung,double rating)
        {
            if(HttpContext.Session.Get<KhachHang>("user") != null)
            {
                if(ViewBag.ErrorCmt != null)
                {
                    ViewBag.ErrorCmt = null;
                }
                BinhLuanSp cmt = new BinhLuanSp
                {
                    NoiDung = noidung,
                    NgayBl = DateTime.Now,
                    MaKh = HttpContext.Session.Get<KhachHang>("user").MaKh,
                    MaHh = mahh
                };
                HangHoa hh = db.HangHoa.SingleOrDefault(p=>p.MaHh == mahh);
                KhachHang kh = HttpContext.Session.Get<KhachHang>("user");
                
                db.BinhLuanSp.Add(cmt);
               
                db.SaveChanges();
                YeuThich yt = new YeuThich
                {
                    MaHh = hh.MaHh,
                    MaKh = kh.MaKh,
                    NgayChon = DateTime.Now,
                    DiemDanhGia = rating,
                    MaBl = cmt.MaBl
                };
                db.YeuThich.Add(yt);
                db.SaveChanges();
                return View("ChiTiet", hh);
            }
            else
            {
                HangHoa hh = db.HangHoa.SingleOrDefault(p => p.MaHh == mahh);
                ViewBag.ErrorCmt = "Vui lòng đăng nhập để bình luận";
                return View("ChiTiet",hh);
            }
        }
    }
}
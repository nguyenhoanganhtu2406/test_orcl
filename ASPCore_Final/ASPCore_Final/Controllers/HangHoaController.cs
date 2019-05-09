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
        private readonly ModelContext db;
        public HangHoaController(ModelContext ctx)
        {
            db = ctx;
        }

        
        public IActionResult Index(string loai="", bool? gioitinh = null, int page = 1, int pageSize = 6)
        {
            int starIndex = (page - 1) * pageSize;
            List<Hanghoa> hangHoas =  db.Hanghoa.Skip(starIndex).ToList();
            if (gioitinh != null)
            {
                hangHoas = db.Hanghoa.Where(p => p.MaloaiNavigation.Gioitinh == gioitinh).Skip(starIndex).ToList();
            }
            else if(loai != null && loai != "")
            {
                hangHoas = db.Hanghoa.Where(p => p.Maloai == loai).Skip(starIndex).ToList();
            }
            int itemsize = hangHoas.Count < pageSize ? hangHoas.Count : pageSize;
            List<Hanghoa> res = hangHoas.Take(itemsize).ToList();
            ViewData["TongSoLuong"] = hangHoas.Count;
            return View("Index",res);
        }

        public IActionResult TaiThem(string loai = "", bool? gioitinh = null, string mucgia = "", string sapxep = "", int page = 2, int pageSize = 6)
        {
            int starIndex = (page - 1) * pageSize;

            List<Hanghoa> hangHoas = db.Hanghoa.ToList();
            List<HangHoaBanChayModel> hangHoaBanChays = new List<HangHoaBanChayModel>();
            if (gioitinh != null)
            {
                hangHoas = db.Hanghoa.Where(p => p.MaloaiNavigation.Gioitinh == gioitinh).ToList();
            }
            else if (loai != null && loai != "")
            {
                hangHoas = db.Hanghoa.Where(p => p.Maloai == loai).ToList();
            }
            switch (mucgia)
            {
                case "100000":
                    hangHoas = hangHoas.Where(p => p.Dongia * (1 - p.Giamgia) < 100000).ToList();
                    break;
                case "200000":
                    hangHoas = hangHoas.Where(p => p.Dongia * (1 - p.Giamgia) >= 100000 && p.Dongia * (1 - p.Giamgia) < 200000).ToList();
                    break;
                case "300000":
                    hangHoas = hangHoas.Where(p => p.Dongia * (1 - p.Giamgia) >= 200000 && p.Dongia * (1 - p.Giamgia) < 300000).ToList();
                    break;
                default:
                    break;
            }
            switch (sapxep)
            {
                case "tang":
                    hangHoas = hangHoas.OrderBy(p => p.Dongia * (1 - p.Giamgia)).ToList();
                    break;
                case "giam":
                    hangHoas = hangHoas.OrderByDescending(p => p.Dongia * (1 - p.Giamgia)).ToList();
                    break;
                case "moinhat":
                    hangHoas = hangHoas.OrderByDescending(p => p.Mahh).ToList();
                    break;
                case "banchay":
                    hangHoaBanChays = hangHoas.Join(db.Chitiethd,
                                             hh => hh.Mahh,
                                             cthd => cthd.Mahh,
                                             (hh, cthd) => new { HHoa = hh, CTiet = cthd })
                                       .Join(db.Hoadon.Where(hd => (DateTime.Now - hd.Ngaydat).TotalDays <= 30),
                                             hhcthd => hhcthd.CTiet.Mahd,
                                             hd => hd.Mahd,
                                             (hhcthd, hd) => new { HHCTHD = hhcthd, HDon = hd })
                                       .GroupBy(g => new { g.HHCTHD.HHoa.Mahh, g.HHCTHD.HHoa.Tenhh, g.HHCTHD.HHoa.Hinh, g.HHCTHD.HHoa.Mota, g.HHCTHD.HHoa.Dongia, g.HHCTHD.HHoa.Giamgia })
                                       .OrderByDescending(g => g.Sum(t => t.HHCTHD.CTiet.Soluong))
                                       .Select(group => new HangHoaBanChayModel
                                       {
                                            MaHH = group.Key.Mahh,
                                            TenHH = group.Key.Tenhh,
                                            HAnh = group.Key.Hinh,
                                            MTa = group.Key.Mota,
                                            DGIa =  Convert.ToDouble(group.Key.Dongia),
                                            GGia = Convert.ToDouble(group.Key.Giamgia),
                                            TongSoBan = group.Sum(t => t.HHCTHD.CTiet.Soluong)
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
                List<Hanghoa> res = hangHoas.Take(itemsize).ToList();
                ViewData["TongSoLuong"] = hangHoas.Count;
                return PartialView(res);
            }
        }

        public IActionResult Filter(string loai = "", bool? gioitinh = null, string mucgia = "", string sapxep = "", int page = 1, int pageSize = 6)
        {
            int starIndex = (page - 1) * pageSize;

            List<Hanghoa> hangHoas = db.Hanghoa.ToList();
            List<HangHoaBanChayModel> hangHoaBanChays = new List<HangHoaBanChayModel>();
            if (gioitinh != null)
            {
                hangHoas = db.Hanghoa.Where(p => p.MaloaiNavigation.Gioitinh == gioitinh).ToList();
            }
            else if (loai != null && loai != "")
            {
                hangHoas = db.Hanghoa.Where(p => p.Maloai == loai).ToList();
            }
            switch (mucgia)
            {
                case "100000":
                    hangHoas = hangHoas.Where(p => p.Dongia * (1 - p.Giamgia) < 100000).ToList();
                    break;
                case "200000":
                    hangHoas = hangHoas.Where(p => p.Dongia * (1 - p.Giamgia) >= 100000 && p.Dongia * (1 - p.Giamgia) < 200000).ToList();
                    break;
                case "300000":
                    hangHoas = hangHoas.Where(p => p.Dongia * (1 - p.Giamgia) >= 200000 && p.Dongia * (1 - p.Giamgia) < 300000).ToList();
                    break;
                default:
                    break;
            }
            switch (sapxep)
            {
                case "tang":
                    hangHoas = hangHoas.OrderBy(p => p.Dongia * (1 - p.Giamgia)).ToList();
                    break;
                case "giam":
                    hangHoas = hangHoas.OrderByDescending(p => p.Dongia * (1 - p.Giamgia)).ToList();
                    break;
                case "moinhat":
                    hangHoas = hangHoas.OrderByDescending(p => p.Mahh).ToList();
                    break;
                case "banchay":
                    hangHoaBanChays = hangHoas.Join(db.Chitiethd,
                                             hh => hh.Mahh,
                                             cthd => cthd.Mahh,
                                             (hh, cthd) => new { HHoa = hh, CTiet = cthd })
                                       .Join(db.Hoadon.Where(hd => (DateTime.Now - hd.Ngaydat).TotalDays <= 30),
                                             hhcthd => hhcthd.CTiet.Mahd,
                                             hd => hd.Mahd,
                                             (hhcthd, hd) => new { HHCTHD = hhcthd, HDon = hd })
                                       .GroupBy(g => new { g.HHCTHD.HHoa.Mahh, g.HHCTHD.HHoa.Tenhh, g.HHCTHD.HHoa.Hinh, g.HHCTHD.HHoa.Mota, g.HHCTHD.HHoa.Dongia, g.HHCTHD.HHoa.Giamgia })
                                       .OrderByDescending(g => g.Sum(t => t.HHCTHD.CTiet.Soluong))
                                       .Select(group => new HangHoaBanChayModel
                                       {
                                           MaHH = group.Key.Mahh,
                                           TenHH = group.Key.Tenhh,
                                           HAnh = group.Key.Hinh,
                                           MTa = group.Key.Mota,
                                           DGIa = Convert.ToDouble(group.Key.Dongia),
                                           GGia = Convert.ToDouble(group.Key.Giamgia),
                                           TongSoBan = group.Sum(t => t.HHCTHD.CTiet.Soluong)
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
                List<Hanghoa> res = hangHoas.Take(itemsize).ToList();
                ViewData["TongSoLuong"] = hangHoas.Count;
                return PartialView(res);
            }
        }

        public IActionResult ChiTiet(int mahh)
        {
            Hanghoa hh = db.Hanghoa.SingleOrDefault(p => p.Mahh == mahh);
            return View(hh);
        }

        public IActionResult TimKiem(string keyword)
        {
            List<Hanghoa> hh = new List<Hanghoa>();
            if(keyword != null)
            {
                hh = db.Hanghoa.Where(p => p.Tenhh.ToLower().Contains(keyword.ToLower())).Take(6).ToList();
            }
            return View(hh);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCore_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace ASPCore_Final.Controllers
{
    public class MyHoaDonsController : Controller
    {
        private readonly ModelContext db;
        public MyHoaDonsController(ModelContext ctx)
        {
            db = ctx;
        }
        public async Task<IActionResult> Index(int page = 1, string sortExpression = "MaHd")
        {

            if (HttpContext.Session.Get<Khachhang>("user") != null)
            {
                Khachhang kh = HttpContext.Session.Get<Khachhang>("user");
                var eSHOPContext = db.Hoadon.Where(p => p.Makh == kh.Makh).OrderByDescending(p=>p.Ngaydat).AsNoTracking().AsQueryable();
                var model = await PagingList.CreateAsync(eSHOPContext, 5, page, sortExpression, "Mahd");
                return View(model);
            }
            else
            {
                var eSHOPContexts = db.Hoadon.Where(p => p.Makh == 0).AsNoTracking().AsQueryable();
                var models = await PagingList.CreateAsync(eSHOPContexts, 5, page, sortExpression, "Mahd");
                return View(models);
            }
        }

        public IActionResult HuyHoaDon(int mahd)
        {
            // xóa các chi tiết hóa đơn liên quan
            List<Chitiethd> listCT_Xoa = db.Chitiethd.Where(p => p.Mahd == mahd).ToList();
            foreach (var item in listCT_Xoa)
            {
                db.Chitiethd.Remove(item);
            }
            db.SaveChanges();
            // xóa hóa đơn
            Hoadon hd = db.Hoadon.Find(mahd);
            db.Hoadon.Remove(hd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult XoaCTHD(int mact)
        {
            Chitiethd ct = db.Chitiethd.Find(mact);
            if(ct != null)
            {
                db.Chitiethd.Remove(ct);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
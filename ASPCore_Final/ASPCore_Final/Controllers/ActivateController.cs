using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCore_Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore_Final.Controllers
{
    public class ActivateController : Controller
    {
        private readonly ModelContext db;
        public ActivateController(ModelContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Activate()
        {
            Khachhang k = HttpContext.Session.Get<Khachhang>("kh");
            if (k != null)
            {
                k.Trangthaihd = true;
                db.Update(k);
                db.SaveChangesAsync();
                HttpContext.Session.Remove("kh");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("Lỗi", "Không tìm thấy tài khoản. Bạn cần thực hiện đăng kí tài khoản!");
                return View("Index");
            }
        }
    }
}
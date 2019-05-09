﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPCore_Final.Models;

namespace ASPCore_Final.Controllers
{
    public class LoginController : Controller
    {
        private readonly ModelContext db;
        public LoginController(ModelContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginKH model)
        {
            if (ModelState.IsValid)
            {
                Khachhang kh = db.Khachhang.SingleOrDefault(p => p.Taikhoan == model.Username && p.Matkhau == Encryptor.MD5Hash(model.Password));
                if (kh == null)
                {
                    ModelState.AddModelError("Lỗi", "Tên đăng nhập hoặc mật khẩu không hợp lệ.");
                    return View("Index");
                }
                else
                {
                    if (kh.Trangthaihd == true)
                    {
                        HttpContext.Session.Set("user", kh);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Lỗi", " Tài khoản bạn chưa được kích hoạt, vui lòng kiểm tra mail để kích hoạt tài khoản");
                        return View("Index");
                    }
                }
            }
               
            return View("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            if (HttpContext.Session.Get<string>("mess") != null)
                HttpContext.Session.Remove("mess");
            return RedirectToAction("Index", "Login");
        }
    }
}
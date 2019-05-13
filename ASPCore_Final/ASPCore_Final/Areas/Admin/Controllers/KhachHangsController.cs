using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPCore_Final.Models;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;

namespace ASPCore_Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhachHangsController : CheckLoginController
    {
        private readonly ModelContext _context;

        public KhachHangsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Admin/KhachHangs
        [HttpGet("/admin/KhachHangs")]
        public async Task<IActionResult> Index(string searchString, int page = 1, string sortExpression = "Email")
        {
            var eSHOPContext = _context.Khachhang.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                eSHOPContext = eSHOPContext.Where(p => p.Email.Contains(searchString) || p.Hoten.Contains(searchString) || p.Taikhoan.Contains(searchString));
            }
            var model = await PagingList.CreateAsync(eSHOPContext, 5, page, sortExpression, "Email");
            model.RouteValue = new RouteValueDictionary {
                { "searchString", searchString}
            };
            return View(model); //(await _context.KhachHang.ToListAsync());
        }

        // GET: Admin/KhachHangs/Details/5
        [HttpGet("/admin/KhachHangs/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.Makh == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: Admin/KhachHangs/Create
        [HttpGet("/admin/KhachHangs/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhachHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makh,Taikhoan,Matkhau,Hoten,Gioitinh,Ngaysinh,Diachi,Dienthoai,Email,Hinh,Trangthaihd")] Khachhang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHang.Matkhau = Encryptor.MD5Hash(khachHang.Matkhau);
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHangs/Edit/5
        [HttpGet("/admin/KhachHangs/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.Khachhang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Makh,Taikhoan,Matkhau,Hoten,Gioitinh,Ngaysinh,Diachi,Dienthoai,Email,Hinh,Trangthaihd")] Khachhang khachHang)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    khachHang.Matkhau = Encryptor.MD5Hash(khachHang.Matkhau);
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.Makh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }
        // DELETE: api/KhachHangs/5
        [HttpDelete("/api/KhachHangs/{id}")]
        public async Task<IActionResult> DeleteKhachHang(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kh = await _context.Khachhang.FindAsync(id);
            if (kh == null)
            {
                return NotFound();
            }

            _context.Khachhang.Remove(kh);
            await _context.SaveChangesAsync();

            return Ok(kh);
        }
       
        [HttpGet("/admin/KhachHangs/ChangeStatus")]
        public IActionResult ChangeStatus(int id)
        {
            var kh = _context.Khachhang.Find(id);
            if (kh != null)
            {
                kh.Trangthaihd = !kh.Trangthaihd;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private bool KhachHangExists(int id)
        {
            return _context.Khachhang.Any(e => e.Makh == id);
        }
    }
}

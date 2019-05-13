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
    
    public class NhanViensController : CheckLoginController
    {
        private readonly ModelContext _context;

        public NhanViensController(ModelContext context)
        {
            _context = context;
        }

        // GET: Admin/NhanViens
        [HttpGet("/admin/NhanViens")]
        public async Task<IActionResult> Index(string searchString, int page = 1, string sortExpression = "Email")
        {
            var eSHOPContext = _context.Nhanvien.AsNoTracking().Include(n => n.MapqNavigation).AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                eSHOPContext = eSHOPContext.Where(p => p.Email.Contains(searchString) || p.Hoten.Contains(searchString));
            }
            var model = await PagingList.CreateAsync(eSHOPContext, 5, page, sortExpression, "Email");
            model.RouteValue = new RouteValueDictionary {
                { "searchString", searchString}
            };
            // var qry = _context.NhanVien.AsNoTracking().OrderBy(p => p.Email);
            // var model = await PagingList.CreateAsync(qry, 1, page);
            return View(model);
        }

        // GET: Admin/NhanViens/Details/5
        [HttpGet("/admin/NhanViens/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.Nhanvien
                .Include(n => n.MapqNavigation)
                .FirstOrDefaultAsync(m => m.Manv == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Create
        [HttpGet("/admin/NhanViens/Create")]
        public IActionResult Create()
        {
            ViewData["Mapq"] = new SelectList(_context.Phanquyen, "Mapq", "Mapq");
            return View();
        }

        // POST: Admin/NhanViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manv,Hoten,Email,Matkhau,Mapq,Trangthaihd")] Nhanvien nhanVien)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(nhanVien.Matkhau)) return null;
                nhanVien.Matkhau = Encryptor.MD5Hash(nhanVien.Matkhau);
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mapq"] = new SelectList(_context.Phanquyen, "Mapq", "Mapq", nhanVien.Mapq);
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Edit/5
        [HttpGet("/admin/NhanViens/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.Nhanvien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["MaPq"] = new SelectList(_context.Phanquyen, "Mapq", "Mapq", nhanVien.Mapq);
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Manv,Hoten,Email,Matkhau,Mapq,Trangthaihd")] Nhanvien nhanVien)
        {

            
            if (ModelState.IsValid)
            {
                try
                {
                    nhanVien.Matkhau = Encryptor.MD5Hash(nhanVien.Matkhau);
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.Manv))
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
            ViewData["Mapq"] = new SelectList(_context.Phanquyen, "Mapq", "Mapq", nhanVien.Mapq);
            return View(nhanVien);
        }

        // DELETE: api/NhanViens/5
        [HttpDelete("/api/NhanViens/{id}")]
        public async Task<IActionResult> DeleteNhanVien( int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nhanVien = await _context.Nhanvien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            _context.Nhanvien.Remove(nhanVien);
            await _context.SaveChangesAsync();

            return Ok(nhanVien);
        }
   
       [HttpGet("/admin/NhanViens/ChangeStatus")]
        public IActionResult ChangeStatus(int id)
        {
            var nhanvien = _context.Nhanvien.Find(id);
            if(nhanvien != null)
            {
                nhanvien.Trangthaihd = !nhanvien.Trangthaihd;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        private bool NhanVienExists(int id)
        {
            return _context.Nhanvien.Any(e => e.Manv == id);
        }
    }
}

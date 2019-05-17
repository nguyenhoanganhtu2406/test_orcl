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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ASPCore_Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HangHoasController : CheckLoginController
    {
        private readonly ModelContext _context;

        public HangHoasController(ModelContext context)
        {
            _context = context;
        }

        // GET: Admin/HangHoas
        [HttpGet("/admin/HangHoas")]
        public async Task<IActionResult> Index(string searchString, int page = 1, string sortExpression = "Mahh")
        {
            var eSHOPContext = _context.Hanghoa.AsNoTracking().Include(h => h.MaloaiNavigation).Include(h => h.ManccNavigation).AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                eSHOPContext = eSHOPContext.Where(p => p.Tenhh.Contains(searchString.ToUpper()) || p.Mancc.Contains(searchString) || p.Maloai.Contains(searchString));
            }
            var model = await PagingList.CreateAsync(eSHOPContext, 5, page, sortExpression, "Mahh");
            model.RouteValue = new RouteValueDictionary {
                { "searchString", searchString}
            };
           // var eSHOPContext = _context.HangHoa.Include(h => h.MaLoaiNavigation).Include(h => h.MaNccNavigation);
            return View(model); //(await eSHOPContext.ToListAsync());
        }

        // GET: Admin/HangHoas/Details/5
        [HttpGet("/admin/HangHoas/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.Hanghoa
                .Include(h => h.MaloaiNavigation)
                .Include(h => h.ManccNavigation)
                .FirstOrDefaultAsync(m => m.Mahh == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // GET: Admin/HangHoas/Create
        [HttpGet("/admin/HangHoas/Create")]
        public IActionResult Create()
        {
            ViewData["Maloai"] = new SelectList(_context.Loai, "Maloai", "Maloai");
            ViewData["Mancc"] = new SelectList(_context.Nhacungcap, "Mancc", "Mancc");
            return View();
        }

        // POST: Admin/HangHoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahh,Tenhh,Maloai,Hinh,Dongia,Giamgia,Mota,Mancc,Soluonghang")] Hanghoa hangHoa, IFormFile fHinh)
        {
            if (ModelState.IsValid)
            {
                if (fHinh != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HangHoa", fHinh.FileName);
                    using (var file = new FileStream(path, FileMode.Create))
                    {
                        fHinh.CopyTo(file);
                    }
                    hangHoa.Hinh = fHinh.FileName;
                }
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Maloai"] = new SelectList(_context.Loai, "Maloai", "Maloai", hangHoa.Maloai);
            ViewData["Mancc"] = new SelectList(_context.Nhacungcap, "Mancc", "Mancc", hangHoa.Mancc);
            return View(hangHoa);
        }

        // GET: Admin/HangHoas/Edit/5
        [HttpGet("/admin/HangHoas/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.Hanghoa.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }
            ViewData["Maloai"] = new SelectList(_context.Loai, "Maloai", "Maloai", hangHoa.Maloai);
            ViewData["Mancc"] = new SelectList(_context.Nhacungcap, "Mancc", "Mancc", hangHoa.Mancc);
            return View(hangHoa);
        }

        // POST: Admin/HangHoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mahh,Tenhh,Maloai,Hinh,Dongia,Giamgia,Mota,Mancc,Soluonghang")] Hanghoa hangHoa, IFormFile fHinh)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    if (fHinh != null)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HangHoa", fHinh.FileName);
                        using (var file = new FileStream(path, FileMode.Create))
                        {
                            fHinh.CopyTo(file);
                        }
                        hangHoa.Hinh = fHinh.FileName;
                    }
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.Mahh))
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
            ViewData["Maloai"] = new SelectList(_context.Loai, "Maloai", "Maloai", hangHoa.Maloai);
            ViewData["Mancc"] = new SelectList(_context.Nhacungcap, "Mancc", "Mancc", hangHoa.Mancc);
            return View(hangHoa);
        }
        // DELETE: api/HangHoas/5
        [HttpDelete("/api/HangHoas/{id}")]
        public async Task<IActionResult> DeleteHangHoa(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hh = await _context.Hanghoa.FindAsync(id);
            if (hh == null)
            {
                return NotFound();
            }

            _context.Hanghoa.Remove(hh);
            await _context.SaveChangesAsync();

            return Ok(hh);
        }
        private bool HangHoaExists(int id)
        {
            return _context.Hanghoa.Any(e => e.Mahh == id);
        }
    }
}

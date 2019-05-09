using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPCore_Final.Models;
using Microsoft.AspNetCore.Routing;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ASPCore_Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TinTucsController : Controller
    {
        private readonly ESHOPContext _context;

        public TinTucsController(ESHOPContext context)
        {
            _context = context;
        }

        // GET: Admin/TinTucs
        [HttpGet("/admin/TinTucs")]
        public async Task<IActionResult> Index(string searchString, int page = 1, string sortExpression = "NgayTao")
        {
            var eSHOPContext = _context.TinTuc.AsNoTracking().Include(t => t.LoaiTtNavigation).Include(t => t.MaNvNavigation).AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                eSHOPContext = eSHOPContext.Where(p => p.LoaiTt.Contains(searchString) || p.MaNv.ToString().Contains(searchString) || p.NgayTao.ToString().Contains(searchString));
            }
            var model = await PagingList.CreateAsync(eSHOPContext, 5, page, sortExpression, "NgayTao");
            model.RouteValue = new RouteValueDictionary {
                { "searchString", searchString}
            };
         
            return View(model);
            //var eSHOPContext = _context.TinTuc.Include(t => t.LoaiTtNavigation).Include(t => t.MaNvNavigation);
            //return View(await eSHOPContext.ToListAsync());
        }

        // GET: Admin/TinTucs/Details/5
        [HttpGet("/admin/TinTucs/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTuc
                .Include(t => t.LoaiTtNavigation)
                .Include(t => t.MaNvNavigation)
                .FirstOrDefaultAsync(m => m.MaTt == id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Create
        [HttpGet("/admin/TinTucs/Create")]
        public IActionResult Create()
        {
            ViewData["LoaiTt"] = new SelectList(_context.LoaiTinTuc, "LoaiTt", "LoaiTt");
            ViewData["MaNv"] = new SelectList(_context.NhanVien, "MaNv", "Email");
            return View();
        }

        // POST: Admin/TinTucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTt,NoiDung,NgayTao,MaNv,LoaiTt,TrangThai,TieuDe")] TinTuc tinTuc, IFormFile fHinh)
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
                    tinTuc.Hinh = fHinh.FileName;
                }
                _context.Add(tinTuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiTt"] = new SelectList(_context.LoaiTinTuc, "LoaiTt", "LoaiTt", tinTuc.LoaiTt);
            ViewData["MaNv"] = new SelectList(_context.NhanVien, "MaNv", "Email", tinTuc.MaNv);
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Edit/5
        [HttpGet("/admin/TinTucs/Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuc = await _context.TinTuc.FindAsync(id);
            if (tinTuc == null)
            {
                return NotFound();
            }
            ViewData["LoaiTt"] = new SelectList(_context.LoaiTinTuc, "LoaiTt", "LoaiTt", tinTuc.LoaiTt);
            ViewData["MaNv"] = new SelectList(_context.NhanVien, "MaNv", "Email", tinTuc.MaNv);
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTt,NoiDung,NgayTao,MaNv,LoaiTt,TrangThai,TieuDe")] TinTuc tinTuc)
        {
         

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinTuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinTucExists(tinTuc.MaTt))
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
            ViewData["LoaiTt"] = new SelectList(_context.LoaiTinTuc, "LoaiTt", "LoaiTt", tinTuc.LoaiTt);
            ViewData["MaNv"] = new SelectList(_context.NhanVien, "MaNv", "Email", tinTuc.MaNv);
            return View(tinTuc);
        }
        // DELETE: api/TinTucs/5
        [HttpDelete("/api/TinTucs/{id}")]
        public async Task<IActionResult> DeleteTinTuc(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tt = await _context.TinTuc.FindAsync(id);
            if (tt == null)
            {
                return NotFound();
            }

            _context.TinTuc.Remove(tt);
            await _context.SaveChangesAsync();

            return Ok(tt);
        }


        private bool TinTucExists(int id)
        {
            return _context.TinTuc.Any(e => e.MaTt == id);
        }
    }
}

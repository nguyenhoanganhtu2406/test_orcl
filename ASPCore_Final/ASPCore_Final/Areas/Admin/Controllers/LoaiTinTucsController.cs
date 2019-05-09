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
    public class LoaiTinTucsController : Controller
    {
        private readonly ESHOPContext _context;

        public LoaiTinTucsController(ESHOPContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiTinTucs
        [HttpGet("/admin/LoaiTinTucs")]
        public async Task<IActionResult> Index(string searchString, int page = 1, string sortExpression = "LoaiTt")
        {
            var eSHOPContext = _context.LoaiTinTuc.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                eSHOPContext = eSHOPContext.Where(p => p.TenTt.Contains(searchString) );
            }
            var model = await PagingList.CreateAsync(eSHOPContext, 5, page, sortExpression, "TenTt");
            model.RouteValue = new RouteValueDictionary {
                { "searchString", searchString}
            };
            // var qry = _context.NhanVien.AsNoTracking().OrderBy(p => p.Email);
            // var model = await PagingList.CreateAsync(qry, 1, page);
            return View(model);
            //return View(await _context.LoaiTinTuc.ToListAsync());
        }

        // GET: Admin/LoaiTinTucs/Details/5
        [HttpGet("/admin/LoaiTinTucs/Details")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTinTuc = await _context.LoaiTinTuc
                .FirstOrDefaultAsync(m => m.LoaiTt == id);
            if (loaiTinTuc == null)
            {
                return NotFound();
            }

            return View(loaiTinTuc);
        }

        // GET: Admin/LoaiTinTucs/Create
        [HttpGet("/admin/LoaiTinTucs/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiTinTucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoaiTt,TenTt")] LoaiTinTuc loaiTinTuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiTinTuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiTinTuc);
        }

        // GET: Admin/LoaiTinTucs/Edit/5
        [HttpGet("/admin/LoaiTinTucs/Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTinTuc = await _context.LoaiTinTuc.FindAsync(id);
            if (loaiTinTuc == null)
            {
                return NotFound();
            }
            return View(loaiTinTuc);
        }

        // POST: Admin/LoaiTinTucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LoaiTt,TenTt")] LoaiTinTuc loaiTinTuc)
        {
            if (id != loaiTinTuc.LoaiTt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiTinTuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiTinTucExists(loaiTinTuc.LoaiTt))
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
            return View(loaiTinTuc);
        }

        // DELETE: api/LoaiTinTucs/5
        [HttpDelete("/api/LoaiTinTucs/{id}")]
        public async Task<IActionResult> DeleteLoaiTinTuc(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loaitt = await _context.LoaiTinTuc.FindAsync(id);
            if (loaitt == null)
            {
                return NotFound();
            }

            _context.LoaiTinTuc.Remove(loaitt);
            await _context.SaveChangesAsync();

            return Ok(loaitt);
        }
        private bool LoaiTinTucExists(string id)
        {
            return _context.LoaiTinTuc.Any(e => e.LoaiTt == id);
        }
    }
}

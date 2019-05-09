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

namespace ASPCore_Final.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class NhaCungCapsController : CheckLoginController
    {
        private readonly ModelContext _context;

        public NhaCungCapsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Admin/NhaCungCaps
        [HttpGet("/admin/NhaCungCaps")]
        public async Task<IActionResult> Index(string searchString, int page = 1, string sortExpression = "Email")
        {
            var eSHOPContext = _context.Nhacungcap.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                eSHOPContext = eSHOPContext.Where(p => p.Email.Contains(searchString) || p.Tencongty.Contains(searchString) || p.Dienthoai.Contains(searchString));
            }
            var model = await PagingList.CreateAsync(eSHOPContext, 5, page, sortExpression, "Email");
            model.RouteValue = new RouteValueDictionary {
                { "searchString", searchString}
            };
            return View(model); //(await _context.NhaCungCap.ToListAsync());
        }

        // GET: Admin/NhaCungCaps/Details/5
        [HttpGet("/admin/NhaCungCaps/Details")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCap = await _context.Nhacungcap
                .FirstOrDefaultAsync(m => m.Mancc == id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            return View(nhaCungCap);
        }

        // GET: Admin/NhaCungCaps/Create
        [HttpGet("/admin/NhaCungCaps/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaCungCaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNcc,TenCongTy,Email,DienThoai,DiaChi,MoTa")] Nhacungcap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaCungCap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaCungCap);
        }

        // GET: Admin/NhaCungCaps/Edit/5
        [HttpGet("/admin/NhaCungCaps/Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var nhaCungCap = await _context.Nhacungcap.FindAsync(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }
            return View(nhaCungCap);
        }

        // POST: Admin/NhaCungCaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNcc,TenCongTy,Email,DienThoai,DiaChi,MoTa")] Nhacungcap nhaCungCap)
        {
         

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaCungCap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaCungCapExists(nhaCungCap.Mancc))
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
            return View(nhaCungCap);
        }
        // DELETE: api/NhaCungCaps/5
        [HttpDelete("/api/NhaCungCaps/{id}")]
        public async Task<IActionResult> DeleteNhaCungCap(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ncc = await _context.Nhacungcap.FindAsync(id);
            if (ncc == null)
            {
                return NotFound();
            }

            _context.Nhacungcap.Remove(ncc);
            await _context.SaveChangesAsync();

            return Ok(ncc);
        }
    
        private bool NhaCungCapExists(string id)
        {
            return _context.Nhacungcap.Any(e => e.Mancc == id);
        }
    }
}

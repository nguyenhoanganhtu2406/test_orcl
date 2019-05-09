using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCore_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCore_Final.Controllers
{
    public class NewsController : Controller
    {

        private readonly ESHOPContext _context;

        public NewsController(ESHOPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.TinTuc.ToList());
        }
      
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
    }
}
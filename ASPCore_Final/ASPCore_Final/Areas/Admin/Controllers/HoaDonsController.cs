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
using System.Net.Mail;

namespace ASPCore_Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoaDonsController : Controller
    {
        private readonly ModelContext _context;

        public HoaDonsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Admin/HoaDons
        [HttpGet("/admin/HoaDons")]
        public async Task<IActionResult> Index(string searchString, int page = 1, string sortExpression = "MatrangthaiNavigation")
        {
            var eSHOPContext = _context.Hoadon.AsNoTracking().Include(h => h.MakhNavigation).Include(h => h.MatrangthaiNavigation).AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                eSHOPContext = eSHOPContext.Where(p => p.Hoten.Contains(searchString) || p.SdtNguoinhan.Contains(searchString) || p.Mahd.ToString().Contains(searchString));
            }
            var model = await PagingList.CreateAsync(eSHOPContext, 5, page, sortExpression, "Mahd");
            model.RouteValue = new RouteValueDictionary {
                { "searchString", searchString}
            };
           // var eSHOPContext = _context.HoaDon.Include(h => h.MaKhNavigation).Include(h => h.MaTrangThaiNavigation);
            return View(model);
        }

        // GET: Admin/HoaDons/Details/5
        [HttpGet("/admin/HoaDons/Details")]
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ct = _context.Chitiethd.Where(p => p.Mahd == id).ToList();
            if (ct == null)
            {
                return NotFound();
            }

            return View(ct);
        }
        
        [HttpGet("/admin/HoaDons/ChangeStatus")]
        public IActionResult ChangeStatus(int id)
        {
            var hd = _context.Hoadon.Find(id);
            if (hd != null)
            {
                hd.Matrangthai = 1;
                _context.SaveChanges();
                Khachhang kh = _context.Khachhang.SingleOrDefault(p=>p.Makh==hd.Makh);
                MailMessage mm = new MailMessage("eshoppingmanager@gmail.com", kh.Email);
                mm.Subject = "Thông báo đơn hàng";
                string content = "<h1>{0}</h1> <br/> <div class='text text-success'><h2>Chào mừng bạn đến với ESHOP.</h2></div> <br> <h5>Bạn vừa tạo một đơn hàng ở ESHOP. Đơn hàng của bạn đã được gửi tới cửa hàng : <br/> Thông tin đơn hàng : <br/>";
                content = content + "<table border='1px' style='font-size:15px;border-collapse: collapse;text-align:center'><tr><th>Tên sản phẩm</th><th>Kích cở</th><th>Số lượng</th><th>Đơn giá</th><th>Thành tiền</th></tr>";
                double tongtien = 0;
                List<Chitiethd> cthd = _context.Chitiethd.Where(p => p.Mahd == hd.Mahd).ToList();
                foreach (var item in cthd)
                {
                    Hanghoa hangHoa = _context.Hanghoa.SingleOrDefault(p => p.Mahh == item.Mahh);
                    var giamgia = item.Dongia - item.Dongia * item.Giamgia;
                    CartItem ct = new CartItem
                    {
                        MaHh = hangHoa.Mahh,
                        TenHh = hangHoa.Tenhh,
                        Hinh = hangHoa.Hinh,
                        KichCo = item.Kichco,
                        GiaBan = Convert.ToDouble(giamgia),
                        SoLuong = item.Soluong
                    };

                    tongtien += ct.ThanhTien;
                    content = content + "<tr><td>" + hangHoa.Tenhh + "</td><td>" + item.Kichco + "</td><td>" + item.Soluong + "</td><td>" + ct.GiaBan.ToString("#,##0") +"</td><td>" + ct.ThanhTien.ToString("#,##0") + "</td></tr>";
                }
                _context.SaveChanges();
                content = content + "<tr><td colspan='4'>Tông thanh toán : </td><td>" + tongtien.ToString("#,##0") + "</td></tr></table><br />";
                content = content + "<div>Đơn hàng của bạn sẽ được chuyển đến trong vài ngày tới . Cảm ơn bạn đã ủng hộ ESHOP. Thân</div>";
                mm.Body = string.Format(content, kh.Hoten);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("eshoppingmanager@gmail.com", "eshop147258369");
                smtp.Send(mm);
            }
            return RedirectToAction("Index");
        }


        private bool HoaDonExists(int id)
        {
            return _context.Hoadon.Any(e => e.Mahd == id);
        }
    }
}

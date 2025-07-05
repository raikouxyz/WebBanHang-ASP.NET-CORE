using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Data;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        // khai báo DbContext chỉ đọc
        private readonly WebBanHangContext _context;

        // constructor
        public ProductController (WebBanHangContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.Product.ToListAsync();
        }
    }
}

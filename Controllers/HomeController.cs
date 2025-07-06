using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models;
using WebBanHang.Data;
using Microsoft.EntityFrameworkCore;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebBanHangContext _context;

        public HomeController(ILogger<HomeController> logger, WebBanHangContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Product.ToListAsync();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

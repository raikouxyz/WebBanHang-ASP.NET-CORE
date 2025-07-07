using Microsoft.AspNetCore.Mvc;
using WebBanHang.Admin;

namespace WebBanHang.Controllers
{
    [ServiceFilter(typeof(Authorization))]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}

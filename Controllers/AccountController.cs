using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Data;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class AccountController : Controller
    {
        // khai báo chỉ đọc database
        private readonly WebBanHangContext _context;

        // constructor
        public AccountController(WebBanHangContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Action trả về view trang đăng ký
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Chức năng đăng ký
        // Action xử lý dữ liệu đăng ký
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            // kiểm tra dữ liệu gửi lên có hợp lệ không, 
            if (ModelState.IsValid)
            {
                // tìm kiếm trong database xem có Email đã tồn tại chưa
                if (await _context.User.AnyAsync(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email đã được sử dụng");

                    // trả về trang view với dữ liệu cũ người dùng đã nhập
                    return View(user);
                }
                else
                {
                    // Hash mật khẩu trước khi lưu
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
                    user.Role = UserRole.User;
                    // thêm user vào database
                    _context.Add(user);
                    // lưu dữ liệu xuống database
                    await _context.SaveChangesAsync();

                    // chuyển hướng đến action Login
                    return RedirectToAction("Login");
                }
            }
            else
            {
                // trả về trang view với dữ liệu cũ người dùng đã nhập
                return View(user);
            }
        }

        // Action trả về view đăng ký
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Chức năng đăng nhập
        // Action xử lý dữ liệu đăng nhập
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Tìm user theo email
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == email);

            // Kiểm tra user tồn tại và verify password
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                // Lưu session
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserRole", user.Role.ToString());
                
                // kiểm tra role để chuyển hướng phù hợp
                if (user.Role == UserRole.Admin)
                {
                    // nếu là admin, chuyển hướng tới trang admin
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    // nếu là user thường, chuyển về trang chủ
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Error = "Email hoặc mật khẩu không đúng.";
                return View();
            }    
        }

        // đăng xuất
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

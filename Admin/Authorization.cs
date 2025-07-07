
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebBanHang.Models;

namespace WebBanHang.Admin
{
    public class Authorization : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Lấy role từ session
            var userRole = context.HttpContext.Session.GetString("UserRole");

            // Kiểm tra nếu không phải admin thì chuyển hướng về trang chủ
            if (string.IsNullOrEmpty(userRole) || userRole != UserRole.Admin.ToString())
            {
                // Chuyển hướng về trang chủ
                context.Result = new RedirectToActionResult("Index", "Home", null);
                return;
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}

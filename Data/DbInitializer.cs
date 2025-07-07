using System;
using System.Linq;
using WebBanHang.Models;
using BCrypt.Net;

namespace WebBanHang.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebBanHangContext context)
        {
            // Đảm bảo database đã được tạo
            context.Database.EnsureCreated();

            // Seed Admin User
            SeedAdmin(context);
        }

        private static void SeedAdmin(WebBanHangContext context)
        {
            // Kiểm tra xem đã có admin chưa
            if (!context.User.Any(u => u.Email == "admin@gmail.com"))
            {
                var admin = new User
                {
                    Name = "Administrator",
                    Email = "admin@gmail.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
                    Role = UserRole.Admin,
                    CreatedAt = DateTime.Now
                };

                context.User.Add(admin);
                context.SaveChanges();
                Console.WriteLine("Admin account created successfully!");
            }
            else
            {
                Console.WriteLine("Admin account already exists.");
            }
        }
    }
} 
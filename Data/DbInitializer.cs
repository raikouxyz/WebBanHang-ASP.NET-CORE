using System;
using System.Linq;
using WebBanHang.Models;

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

            // Seed Products
            SeedProducts(context);
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
                    PasswordHash = "123",
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

        private static void SeedProducts(WebBanHangContext context)
        {
            // Kiểm tra xem đã có sản phẩm chưa
            if (!context.Product.Any())
            {
                var products = new Product[]
                {
                    new Product { Name = "Áo thun nam", Description = "Áo thun cotton cao cấp", Price = 150000, Quantity = 50 },
                    new Product { Name = "Quần jean nữ", Description = "Quần jean co giãn", Price = 250000, Quantity = 30 },
                    new Product { Name = "Giày sneaker", Description = "Giày thể thao thời trang", Price = 500000, Quantity = 20 },
                    new Product { Name = "Balo laptop", Description = "Balo chống sốc cho laptop 15 inch", Price = 350000, Quantity = 15 },
                    new Product { Name = "Mũ lưỡi trai", Description = "Mũ thời trang nam nữ", Price = 80000, Quantity = 40 },
                    new Product { Name = "Áo khoác gió", Description = "Áo khoác nhẹ chống nước", Price = 220000, Quantity = 25 },
                    new Product { Name = "Váy công sở", Description = "Váy liền thân nữ công sở", Price = 300000, Quantity = 18 },
                    new Product { Name = "Túi xách nữ", Description = "Túi xách thời trang", Price = 400000, Quantity = 12 },
                    new Product { Name = "Đồng hồ nam", Description = "Đồng hồ dây da cao cấp", Price = 1200000, Quantity = 10 },
                    new Product { Name = "Kính mát", Description = "Kính mát chống tia UV", Price = 180000, Quantity = 22 }
                };

                context.Product.AddRange(products);
                context.SaveChanges();
                Console.WriteLine($"{products.Length} products created successfully!");
            }
            else
            {
                Console.WriteLine("Products already exist.");
            }
        }
    }
} 
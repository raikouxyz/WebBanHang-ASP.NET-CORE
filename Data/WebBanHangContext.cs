using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Models;

namespace WebBanHang.Data
{
    public class WebBanHangContext : DbContext
    {
        public WebBanHangContext (DbContextOptions<WebBanHangContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}

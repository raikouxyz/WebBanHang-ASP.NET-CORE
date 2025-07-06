using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebBanHang.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebBanHangContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebBanHangContext") ?? throw new InvalidOperationException("Connection string 'WebBanHangContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

// Seed dữ liệu mẫu cho Product
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<WebBanHangContext>();
    WebBanHang.Data.DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

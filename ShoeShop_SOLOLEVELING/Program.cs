using AutoMapper;
using Microsoft.AspNetCore.Builder;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
=======
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// --- FINAL CLEAN USING STATEMENTS (Fixes all CS0246 errors) ---
// Ang lahat ng ito ay kinakailangan para makita ang classes at interfaces
>>>>>>> origin/memberC
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Repository.Repositories;
using ShoeShop.Services.Interfaces;
using ShoeShop.Services.Mapping;
using ShoeShop.Services.Services;
<<<<<<< HEAD


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Server=localhost;Database=ShoeShopDb;Trusted_Connection=True;MultipleActiveResultSets=true")
);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(ShoeShop.Services.Services.InventoryService));

builder.Services.AddControllersWithViews();

=======
// ---

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURE DATABASE CONTEXT
builder.Services.AddDbContext<ShoeShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Server=localhost;Database=ShoeShopDb;Trusted_Connection=True;MultipleActiveResultSets=true")
);

builder.Services.AddAutoMapper(typeof(MappingProfile));
// Add services to the container.
builder.Services.AddControllersWithViews();


// 2. CONFIGURE AUTO MAPPER 
// Ito ang tamang paraan para i-target ang mapping profiles sa Services project
builder.Services.AddAutoMapper(typeof(ShoeShop.Services.Services.InventoryService));


// 3. REGISTER REPOSITORIES (Gamit ang AddScoped)
>>>>>>> origin/memberC
builder.Services.AddScoped<IShoeRepository, ShoeRepository>();
builder.Services.AddScoped<IStockPullOutRepository, StockPullOutRepository>();


<<<<<<< HEAD
=======
// 4. REGISTER SERVICES (Gamit ang AddScoped)
>>>>>>> origin/memberC
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IPullOutService, PullOutService>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
builder.Services.AddScoped<IReportService, ReportService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

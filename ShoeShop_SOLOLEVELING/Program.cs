using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Data;
using ShoeShop.Repository.Data.Interfaces;
using ShoeShop.Repository.Entities;
using ShoeShop.Repository.Interfaces;
using ShoeShop.Repository.Repositories;
using ShoeShop.Services.Interfaces;
using ShoeShop.Services.Mapping;
using ShoeShop.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// THIS IS THE CORRECTED LINE - It now uses UseSqlServer to match your appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

// --- Add AutoMapper ---
builder.Services.AddAutoMapper(typeof(MappingProfile));


// --- REPOSITORY AND SERVICE REGISTRATIONS ---

// Repositories
builder.Services.AddScoped<IShoeRepository, ShoeRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IStockPullOutRepository, StockPullOutRepository>();


// Services
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IPullOutService, PullOutService>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
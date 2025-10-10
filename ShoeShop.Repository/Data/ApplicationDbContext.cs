using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Repository.Entities;

namespace ShoeShop.Repository.Data
{
    // The class must inherit from IdentityDbContext<ApplicationUser>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Ito ang magiging tables mo sa database
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeColorVariation> ShoeColorVariations { get; set; }
        public DbSet<StockPullOut> StockPullOuts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This line is crucial for Identity to configure its tables
            base.OnModelCreating(modelBuilder);

            // Your existing data seeding can go here if you have any
        }
    }
}

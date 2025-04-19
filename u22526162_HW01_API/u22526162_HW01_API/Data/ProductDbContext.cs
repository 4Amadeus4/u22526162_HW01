using Microsoft.EntityFrameworkCore;
using u22526162_HW01_API.Models;

namespace u22526162_HW01_API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>().Property(p => p.ProductName).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Product>().Property(p => p.ProductPrice).IsRequired().HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>().Property(p => p.ProductDescription).IsRequired().HasMaxLength(250);

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Baseball Cap", ProductPrice = 9.99m, ProductDescription = "A classic baseball cap with adjustable strap, made of breathable cotton. Perfect for casual wear and outdoor activities." },
                new Product { ProductId = 2, ProductName = "Running Shoes", ProductPrice = 99.99m, ProductDescription = "Lightweight and breathable running shoes with cushioned soles for enhanced comfort. Designed for maximum comfort and durability, making them ideal for long-distance running or daily workouts." },
                new Product { ProductId = 3, ProductName = "Blue Shirt", ProductPrice = 49.99m, ProductDescription = "Blue shirt with logo on front, made from breathable cotton." },
                new Product { ProductId = 4, ProductName = "Laptop", ProductPrice = 999.99m, ProductDescription="HP Laptop with Intel i7 CPU, 16GB RAM, 256GB storage, OLED display" },
                new Product { ProductId = 5, ProductName = "Wireless Mouse", ProductPrice = 79.99m, ProductDescription="Bluetooth mouse with RGB lights and wireless charging pad." },
                new Product { ProductId = 6, ProductName = "Portable Power Bank", ProductPrice = 59.86m, ProductDescription= "High-capacity fast-charging power bank for mobile devices." },
                new Product { ProductId = 7, ProductName = "Smartwatch", ProductPrice = 199.34m, ProductDescription = "Feature-packed smartwatch with heart rate monitoring, GPS, and Bluetooth connectivity." },
                new Product { ProductId = 8, ProductName = "Noise-Canceling Headphones", ProductPrice = 149.99m, ProductDescription = "Over-ear wireless headphones with active noise cancellation and long battery life." },
                new Product { ProductId = 9, ProductName = "Gaming Keyboard", ProductPrice = 127.19m, ProductDescription = "Mechanical gaming keyboard with customizable RGB backlighting and programmable macro keys." },
                new Product { ProductId = 10, ProductName = "Camping Tent", ProductPrice = 190.01m, ProductDescription = "Water-resistant, lightweight camping tent suitable for 4 people, easy to set up and carry." }
            );
            }
    }
}

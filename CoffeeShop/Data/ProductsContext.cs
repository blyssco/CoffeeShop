using Microsoft.EntityFrameworkCore;
using CoffeeShop.Models;

namespace CoffeeShop.Data;

internal class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("DB");



    // Override the OnModelCreating method to configure database relationships and schema
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Order>()
                .Property(tp => tp.TotalPrice)
                .HasColumnType("decimal(18, 2)"); // Set precision and scale as needed

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18, 2)");

        // Configure the primary key for the OrderProduct entity as a composite key
        modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });

        // Configure the relationship between OrderProduct and Order entities
        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)            // Each OrderProduct has one associated Order
            .WithMany(op => op.OrderProducts)    // Each Order can have multiple OrderProducts
            .HasForeignKey(op => op.OrderId);   // Use OrderId as the foreign key

        // Configure the relationship between OrderProduct and Product entities
        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)          // Each OrderProduct has one associated Product
            .WithMany(op => op.OrderProducts)    // Each Product can have multiple OrderProducts
            .HasForeignKey(op => op.ProductId); // Use ProductId as the foreign key

        // Configure the relationship between Product and Category entities
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)           // Each Product has one associated Category
            .WithMany(p => p.Products)         // Each Category can have multiple Products
            .HasForeignKey(p => p.CategoryId); // Use CategoryId as the foreign key

        modelBuilder.Entity<Category>()
            .HasData(new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Coffee"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Juice"
                }
            });

        modelBuilder.Entity<Product>()
            .HasData(new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Capuccino",
                    Price = 13.0m
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    Name = "Latte",
                    Price = 5.0m
                },            
                new Product
                {
                    ProductId = 3,
                    CategoryId = 2,
                    Name = "Apple juice",
                    Price = 13.0m
                },
                new Product
                {
                    ProductId = 4,
                    CategoryId = 2,
                    Name = "Orange juice",
                    Price = 6.0m
                }
            });
    }

}

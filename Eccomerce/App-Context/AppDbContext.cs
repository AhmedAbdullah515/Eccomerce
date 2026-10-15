using Eccomerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Eccomerce.App_Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base (options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relations
            modelBuilder.Entity<Product>().HasOne(a=>a.Category).WithMany(a=>a.Products)
                .HasForeignKey(a=>a.CategoryId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(a => a.User).WithMany(a => a.Orders)
                .HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderItem>().HasOne(a => a.Order).WithMany(a => a.OrderItems)
                .HasForeignKey(a => a.OrderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderItem>().HasOne(a => a.Product).WithMany(a => a.OrderItems)
                .HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.NoAction);
            //properties
            modelBuilder.Entity<Category>().HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(a=>a.Email).IsUnique();
            //keys
            modelBuilder.Entity<User>().HasKey(a => a.UserId);
            modelBuilder.Entity<Category>().HasKey(a => a.CategoryId);
            modelBuilder.Entity<Product>().HasKey(a => a.ProductId);
            modelBuilder.Entity<Order>().HasKey(a => a.OrderId);
            modelBuilder.Entity<OrderItem>().HasKey(a => a.OrderItemId);
            //dataseeding
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "Ahmed Hassan", Email = "ahmed@example.com@g", Password = "123456A", Role = "Customer" },
                new User { UserId = 2, FullName = "Mona Ali", Email = "Mona@example.com", Password = "123456m", Role = "Customer" },
                new User { UserId = 3, FullName = "Store Admin", Email = "admin@example.com", Password = "123456Adm", Role = "Admin" }
                );
            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryId = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { CategoryId = 2, Name = "Clothing", Description = "Apparel and fashion items" },
                new Category { CategoryId = 3, Name = "Books", Description = "Books and literature" }
                );
            modelBuilder.Entity<Product>().HasData(
                
                new Product { ProductId = 1, ProductName = "Smartphone", Description = "Latest smartphone with advanced features", Price = 699.99m, StockQuantity = 50, CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "Laptop", Description = "High-performance laptop for work and gaming", Price = 1299.99m, StockQuantity = 30, CategoryId = 3 },
                new Product { ProductId = 3, ProductName = "T-shirt", Description = "Comfortable cotton t-shirt in various colors", Price = 19.99m, StockQuantity = 100, CategoryId = 2 }
                );
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, UserId = 1, OrderDate = DateTime.Now, TotalAmount = 699.99m,Satus="Completed" },
                new Order { OrderId = 2, UserId = 2, OrderDate = DateTime.Now, TotalAmount = 19.99m,Satus="Pending" },
                new Order { OrderId = 3, UserId = 3, OrderDate = DateTime.Now, TotalAmount = 1299.99m,Satus="Cancelled" }
                );
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 699.99m },
                new OrderItem { OrderItemId = 2, OrderId = 2, ProductId = 3, Quantity = 1, UnitPrice = 19.99m },
                new OrderItem { OrderItemId = 3, OrderId = 3, ProductId = 2, Quantity = 1, UnitPrice = 1299.99m }
                );
        }
    }
}

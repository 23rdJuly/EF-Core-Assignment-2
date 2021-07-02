
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EF_Core_2.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.CategoryId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category);
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                CategoryName = "Category1",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Product1",
                CategoryId = 1
            });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
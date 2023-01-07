
using Microsoft.EntityFrameworkCore;
using ProductInfo.API.Entities;

namespace ProductInfo.API.DbContexts
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                new Product("Door")
                {
                    Id = 1,
                    Price = 3.99
                },
                new Product("Chair")
                {
                    Id = 2,
                    Price = 6.99
                },
                new Product("Table")
                {
                    Id = 3,
                    Price = 7.99
                });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=.;Database=ProductInfo;User Id=sa;Password=145837;");
            base.OnConfiguring(optionBuilder);
        }
    }
}

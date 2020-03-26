using Microsoft.EntityFrameworkCore;
using Shop.Api.Domain.Models;

namespace Shop.Api.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Good> Goods { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(x=> x.Id);
            builder.Entity<Category>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(x=>x.Name).IsRequired().HasMaxLength(50);

            builder.Entity<Category>().HasData(
                new Category{
                    Id = 10000,
                    Name = "Smartphone",
                },
                new Category{
                    Id = 10001,
                    Name = "Laptop",
                }
            );
            builder.Entity<Good>().ToTable("Goods");
            builder.Entity<Good>().HasKey(x=>x.Id);
            builder.Entity<Good>().Property(x=>x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Good>().Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Good>().HasData(
                new Good{
                    Id = 1,
                    Name = "Iphone",
                    Price = 1000.02
                },
                new Good{
                    Id = 2,
                    Name = "MacBook",
                    Price = 4000.03
                }
            );
        }
    }
}
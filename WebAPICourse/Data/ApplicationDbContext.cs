using Microsoft.EntityFrameworkCore;
using Webapp.Models;

namespace Webapp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Data Seeding

            modelBuilder.Entity<Shirt>().HasData(
            new Shirt { ShirtId = 1, Size = 8, Color = "Red", Brand = "MyBrand", Gender = "Men", Price = 30 },
            new Shirt { ShirtId = 2, Size = 3, Color = "Red", Brand = "MyBrand", Gender = "Men", Price = 30 },
            new Shirt { ShirtId = 3, Size = 5, Color = "Blue", Brand = "YourBrand", Price = 25, Gender = "Women" },
            new Shirt { ShirtId = 4, Size = 6, Color = "Blue", Brand = "YourBrand", Price = 25, Gender = "Women" }
        );


        }
    }
}

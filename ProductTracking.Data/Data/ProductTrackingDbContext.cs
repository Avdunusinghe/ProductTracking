using Microsoft.EntityFrameworkCore;
using ProductTracking.Data.Configuration;
using ProductTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracking.Data.Data
{
    public class ProductTrackingDbContext : DbContext
    {
        public ProductTrackingDbContext()
        {

        }

        public ProductTrackingDbContext(DbContextOptions<ProductTrackingDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PSI7D8C\\SQLEXPRESS;Database=ProductTracting;User Id=sa;Password=1qaz2wsx@;");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
    }
}

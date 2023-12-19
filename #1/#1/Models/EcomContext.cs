using Microsoft.EntityFrameworkCore;

namespace _1.Models
{
    public class EcomContext : DbContext
    {
        public EcomContext(DbContextOptions<EcomContext> options) : base(options) 
        { 
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductGallary> productGallarys { get; set;}
    }
}

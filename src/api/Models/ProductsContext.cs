using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<ProductsModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
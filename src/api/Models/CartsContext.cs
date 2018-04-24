using System;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class CartsContext : DbContext
    {
        public CartsContext(DbContextOptions<CartsContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<CartsModel> Carts { get; set; }
        public DbSet<CartProductsModel> CartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
         
            
        }
    }
}
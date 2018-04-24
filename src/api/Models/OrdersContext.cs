using System;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<CartsContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<OrdersModel> Orders { get; set; }
        public DbSet<OrderProductsModel> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
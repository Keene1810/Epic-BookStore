using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KABookstore.Models;

namespace KABookstore.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public DbSet<Book> Books { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet <ShoppingCartItem> ShoppingCartItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}

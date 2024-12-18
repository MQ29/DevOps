using ApkaNowa.Models;
using Microsoft.EntityFrameworkCore;

namespace ApkaNowa
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin" },
                new User { Id = 2, Name = "User1" }
            );
        }
    }
}

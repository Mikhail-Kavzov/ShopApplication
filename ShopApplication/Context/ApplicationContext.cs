using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Models;

namespace ShopApplication.Context
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

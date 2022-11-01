using Microsoft.EntityFrameworkCore;

namespace MyAspNetCoreApp.Web.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)//super
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

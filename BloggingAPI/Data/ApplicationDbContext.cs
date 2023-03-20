using BloggingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}

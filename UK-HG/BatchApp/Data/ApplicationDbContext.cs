using BatchApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BatchApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BatchModel> Batches { get; set; }

        public DbSet<Models.Atribute> Atributes { get; set; }

        public DbSet<Models.ACL> ACLs { get; set; }
    }
}

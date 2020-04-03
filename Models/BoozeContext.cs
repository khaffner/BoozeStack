using Microsoft.EntityFrameworkCore;

namespace BoozeApi.Models
{
    public class BoozeContext : DbContext
    {
        public BoozeContext(DbContextOptions<BoozeContext> options)
            : base(options)
        {
        }

        public DbSet<BoozeItem> BoozeItems { get; set; }
    }
}
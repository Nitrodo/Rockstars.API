using Microsoft.EntityFrameworkCore;
using Rockstars.Domain.Entities;

namespace Rockstars.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DatabaseContext() { }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }
}

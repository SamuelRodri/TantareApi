using Microsoft.EntityFrameworkCore;
using TantareApi.Entities;

namespace TantareApi.Infrastructure
{
    public class TantareDb : DbContext
    {
        public TantareDb(DbContextOptions<TantareDb> options) : base(options) { }

        public DbSet<World> Worlds => Set<World>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Character> Characters => Set<Character>();
    }
}
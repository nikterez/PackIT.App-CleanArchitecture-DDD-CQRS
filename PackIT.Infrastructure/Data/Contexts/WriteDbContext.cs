using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.Data.Config;
using PackIT.Infrastructure.Data.Models;

namespace PackIT.Infrastructure.Data.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<PackingList> PackingLists { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var config = new WriteConfiguration();

            modelBuilder.ApplyConfiguration<PackingList>(config);
            modelBuilder.ApplyConfiguration<PackingItem>(config);
        }
    }
}

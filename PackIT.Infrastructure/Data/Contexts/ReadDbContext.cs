using Microsoft.EntityFrameworkCore;
using PackIT.Infrastructure.Data.Config;
using PackIT.Infrastructure.Data.Models;

namespace PackIT.Infrastructure.Data.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        public DbSet<PackingListReadModel> PackingLists { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var config = new ReadConfiguration();
     
            modelBuilder.ApplyConfiguration<PackingListReadModel>(config);
            modelBuilder.ApplyConfiguration<PackingItemReadModel>(config);

        }
    }
}

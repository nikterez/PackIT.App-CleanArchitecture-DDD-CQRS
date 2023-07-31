using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.Data.Contexts;

namespace PackIT.Infrastructure.Repositories
{
    internal sealed class PostgresPackingListsRepository : IPackingListRepository
    {
        private readonly DbSet<PackingList> _packingList;
        private readonly WriteDbContext _writeDbContext;

        public PostgresPackingListsRepository(WriteDbContext writeDbContext)
        {
            _packingList = writeDbContext.PackingLists;
            _writeDbContext = writeDbContext;
        }

        public async Task<PackingList> GetByIdAsync(PackingListId id)
        {
            var packingList = _packingList.Include("_items").SingleOrDefaultAsync(pl=>pl.Id == id);

            return await packingList;
        }

        public async Task AddAsync(PackingList packingList)
        {
            await _packingList.AddAsync(packingList);
            await _writeDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(PackingList packingList)
        {
            _packingList.Update(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PackingListId id)
        {
            var packingList = await _packingList.FindAsync(id);
            
            _packingList.Remove(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

    }
}

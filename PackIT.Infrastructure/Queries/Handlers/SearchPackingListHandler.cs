using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTOs;
using PackIT.Application.Queries;
using PackIT.CommonAbstractions.Queries;
using PackIT.Infrastructure.Data.Contexts;
using PackIT.Infrastructure.Data.Models;

namespace PackIT.Infrastructure.Queries.Handlers
{
    internal sealed class SearchPackingListHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDTO>>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public SearchPackingListHandler(ReadDbContext context)
        {
            _packingLists = context.PackingLists;
        }
        public async Task<IEnumerable<PackingListDTO>> HandleAsync(SearchPackingLists query)
        {
            var dbQuery = _packingLists
                .Include(pl => pl.Items)
                .AsQueryable();

            if(query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(pl => EF.Functions.ILike(pl.Name, $"%{query.SearchPhrase}%"));
            }

            var packingListsDTO = dbQuery
                .Select(pl => pl.AsDTO())
                .AsNoTracking()
                .ToListAsync();

            return await packingListsDTO;

        }
    }
}

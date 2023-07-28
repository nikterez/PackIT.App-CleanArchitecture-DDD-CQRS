using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTOs;
using PackIT.Application.Queries;
using PackIT.CommonAbstractions.Queries;
using PackIT.Infrastructure.Data.Contexts;
using PackIT.Infrastructure.Data.Models;

namespace PackIT.Infrastructure.Queries.Handlers
{
    internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDTO>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public GetPackingListHandler(ReadDbContext context)
        {
            _packingLists = context.PackingLists;
        }

        public Task<PackingListDTO> HandleAsync(GetPackingList query)
        {
            var packingListDTO = _packingLists
                .Include(pl => pl.Items)
                .Where(pl => pl.Id == query.Id)
                .Select(pl => pl.AsDTO())
                .AsNoTracking()
                .SingleOrDefaultAsync();

            return packingListDTO;
        }
    }
}

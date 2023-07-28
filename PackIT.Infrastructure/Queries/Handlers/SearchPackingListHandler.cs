using PackIT.Application.DTOs;
using PackIT.Application.Queries;
using PackIT.CommonAbstractions.Queries;

namespace PackIT.Infrastructure.Queries.Handlers
{
    public class SearchPackingListHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDTO>>
    {
        public Task<IEnumerable<PackingListDTO>> HandleAsync(SearchPackingLists query)
        {
            throw new NotImplementedException();
        }
    }
}

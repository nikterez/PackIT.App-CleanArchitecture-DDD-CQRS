using PackIT.Application.DTOs;
using PackIT.Application.Queries;
using PackIT.CommonAbstractions.Queries;

namespace PackIT.Infrastructure.Queries.Handlers
{
    public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDTO>
    {

        public Task<PackingListDTO> HandleAsync(GetPackingList query)
        {
            throw new NotImplementedException();
        }
    }
}

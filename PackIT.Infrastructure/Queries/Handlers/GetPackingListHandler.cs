using PackIT.Application.DTOs;
using PackIT.Application.Queries;
using PackIT.CommonAbstractions.Queries;

namespace PackIT.Infrastructure.Queries.Handlers
{
    public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListReadModel>
    {

        public Task<PackingListReadModel> HandleAsync(GetPackingList query)
        {
            throw new NotImplementedException();
        }
    }
}

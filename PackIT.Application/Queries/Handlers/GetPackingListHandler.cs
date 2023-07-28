using PackIT.Application.DTOs;
using PackIT.CommonAbstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Queries.Handlers
{
    public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDTO>
    {

        public Task<PackingListDTO> HandleAsync(GetPackingList query)
        {
            throw new NotImplementedException();
        }
    }
}

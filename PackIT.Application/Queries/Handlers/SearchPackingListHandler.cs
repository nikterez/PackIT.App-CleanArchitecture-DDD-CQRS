using PackIT.Application.DTOs;
using PackIT.CommonAbstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Queries.Handlers
{
    public class SearchPackingListHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDTO>>
    {
        public Task<IEnumerable<PackingListDTO>> HandleAsync(SearchPackingLists query)
        {
            throw new NotImplementedException();
        }
    }
}

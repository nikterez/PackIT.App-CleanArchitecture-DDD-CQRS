using PackIT.Application.DTOs;
using PackIT.CommonAbstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Queries
{
    public class GetPackingList : IQuery<PackingListDTO>
    {
        public Guid Id { get; set; }
    }
}

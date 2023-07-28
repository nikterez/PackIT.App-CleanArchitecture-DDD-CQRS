using PackIT.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Services
{
    public interface IPackingListReadService
    {
        Task<IEnumerable<PackingListDTO>> SearchAsync(string name);
        Task<bool> CheckPackingListExistsbyName(string name);
    }
}

using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTOs;
using PackIT.Application.Services;
using PackIT.Infrastructure.Data.Contexts;
using PackIT.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Data.Services
{
    internal sealed class PostgresPackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public PostgresPackingListReadService(ReadDbContext context)
        {
            _packingList = context.PackingLists;
        }

        public Task<bool> CheckPackingListExistsbyName(string name) => _packingList.AnyAsync(x => x.Name == name);

    }
}

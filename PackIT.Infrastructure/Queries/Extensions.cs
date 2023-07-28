using PackIT.Application.DTOs;
using PackIT.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static PackingListDTO AsDTO(this PackingListReadModel readModel)
        {
            var newDTO = new PackingListDTO
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Localization = new LocalizationDTO
                {
                    City = readModel.Localization?.City,
                    Country = readModel.Localization?.Country,
                },
                Items = readModel.Items.Select(pi => new PackingItemDTO
                {
                    Name = pi.Name,
                    Quantity = pi.Quantity,
                    IsPacked = pi.IsPacked
                }),
            };

            return newDTO;
        }
    }
}

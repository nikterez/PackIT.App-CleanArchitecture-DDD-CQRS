using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.DTOs
{
    public class PackingListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocalizationDTO Localization { get; set; }
        public IEnumerable<PackingItemDTO> Items { get; set; }
    }
}

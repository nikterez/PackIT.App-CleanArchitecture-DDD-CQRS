using PackIT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.ValueObjects
{
    public class PackingItem
    {
        public string? Name { get; set; }
        public uint Quantity { get; set; }
        public bool IsPacked { get; set; }

        public PackingItem(string? name, uint quantity, bool isPacked)
        {
            Name = string.IsNullOrEmpty(name) ? throw new EmptyPackingListItemNameException() : name;
            Quantity = quantity;
            IsPacked = isPacked;
        }
    }
}

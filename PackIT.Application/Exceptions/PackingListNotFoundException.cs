using PackIT.CommonAbstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class PackingListNotFoundException : PackItException
    {
        public Guid Id { get; }

        public PackingListNotFoundException(Guid id) : base($"Packing list with ID '{id}' was not found.")
            => Id = id;
    }
}

using PackIT.CommonAbstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListItemNameException : PackItException
    {
        public EmptyPackingListItemNameException() : base("Packing Item name cannot be empty")
        {

        }
    }
}

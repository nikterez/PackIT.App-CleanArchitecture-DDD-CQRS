using PackIT.CommonAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListItemNameException : PackItException
    {
        public EmptyPackingListItemNameException() : base("Packing Item name cannot be empty")
        {

        }
    }
}

using PackIT.CommonAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListIdException : PackItException
    {
        public EmptyPackingListIdException() : base("Packing List ID cannot be empty")
        {

        }
    }
}

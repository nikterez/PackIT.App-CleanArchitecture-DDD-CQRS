using PackIT.CommonAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class EmptyPackingListNameException : PackItException
    {
        public EmptyPackingListNameException() : base("Packing List name cannot be empty.")
        {
        }
    }
}

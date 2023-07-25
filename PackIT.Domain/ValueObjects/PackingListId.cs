using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record PackingListId
    {
        public Guid Value { get; }

        public PackingListId(Guid value)
        {
            Value = value == Guid.Empty ? throw new EmptyPackingListIdException() : value;
        }

        public static implicit operator PackingListId(Guid id) => new(id);

        public static implicit operator Guid(PackingListId id) => id.Value;
    }
}
